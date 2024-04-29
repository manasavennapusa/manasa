<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_applyloanadvances_detail.aspx.cs"
    Inherits="payroll_admin_edit_applyloanadvances_detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="payroll" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../../images/loading.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01">Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div id="divapply">
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
                                                                    <td valign="top" class="blue-brdr-1">
                                                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td width="3%">
                                                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                                                                </td>
                                                                                <td class="txt01">Edit Applied Loan/Advances Details
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
                                                                                <td width="29%" class="txt02">Edit Loan/Advances Details
                                                                                </td>
                                                                                <td width="71%" align="right" class="txt-red">
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
                                                                                <td width="30%" class="frm-lft-clr123">Employee Code
                                                                                </td>
                                                                                <td class="frm-rght-clr123">
                                                                                    <asp:Label ID="lbl_empcode" runat="server" Text="Label" Width="182px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="30%" class="frm-lft-clr123">Employee Name
                                                                                </td>
                                                                                <td class="frm-rght-clr123">
                                                                                    <asp:Label ID="lbl_empname" runat="server" Text="Label" Width="182px"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="30%" class="frm-lft-clr123">Loan/Advances Type
                                                                                </td>
                                                                                <td width="70%" class="frm-rght-clr123">
                                                                                    <asp:DropDownList ID="dd_loanname" runat="server" CssClass="span4"
                                                                                        DataSourceID="SqlDataSource1" OnSelectedIndexChanged="dd_loanname_SelectedIndexChanged"
                                                                                        DataTextField="loan_name" DataValueField="id" OnDataBound="dd_loanname_DataBound"
                                                                                        AutoPostBack="True">
                                                                                    </asp:DropDownList>
                                                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="dd_loanname"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        Operator="NotEqual" ValueToCompare="0" ToolTip="Enter Loan/Advances Name"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                        SelectCommand="select [id],[loan_name] from tbl_payroll_loan_advances where status=1"
                                                                                        ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <div id="divloanac" runat="server">
                                                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                                                            <tr>
                                                                                                <td width="30%" class="frm-lft-clr123">Loan/Advances A/c No.
                                                                                                </td>
                                                                                                <td width="70%" class="frm-rght-clr123">
                                                                                                    <asp:Label ID="lbl_acno" runat="server" Text="Label" Width="182px"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="30%" class="frm-lft-clr123">Loan/Advances Reference No.
                                                                                </td>
                                                                                <td width="70%" class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_loanref" runat="server" CssClass="span4" size="30" ToolTip="Loan Reference ID"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfvloanref" runat="server" ControlToValidate="txt_loanref"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ToolTip="Enter Loan Reference ID"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                                                                        ValidationExpression="^[a-zA-Z0-9\.\\\/\-_]+$" ControlToValidate="txt_loanref" ToolTip=" enter only alphabets or numbers"
                                                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v"></asp:RegularExpressionValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="30%" class="frm-lft-clr123">Loan/Advances Amount
                                                                                </td>
                                                                                <td width="70%" class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_loanamnt" runat="server" CssClass="span4" size="30" ToolTip="Loan Amount"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfvloanamnt" runat="server" ControlToValidate="txt_loanamnt"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ToolTip="Enter Loan Amount"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_loanamnt"
                                                                                        Display="Dynamic" ErrorMessage="Enter valid amount" MaximumValue="9999999" MinimumValue="0"
                                                                                        Type="Currency"></asp:RangeValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="30%" class="frm-lft-clr123">Sanction Date
                                                                                </td>
                                                                                <td width="70%" class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_sdate" runat="server" CssClass="span4" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                                                                    <asp:RequiredFieldValidator ID="rfvsdate" runat="server" ControlToValidate="txt_sdate"
                                                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                                                        ToolTip="Select Loan Sanction Date"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                                                        TargetControlID="txt_sdate">
                                                                                    </cc1:CalendarExtender>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="30%" class="frm-lft-clr123">Recover From
                                                                                </td>
                                                                                <td width="70%" class="frm-rght-clr123">
                                                                                    <asp:DropDownList ID="dd_month" runat="server" CssClass="span4">
                                                                                    </asp:DropDownList>
                                                                                    <asp:DropDownList ID="dd_year" runat="server" CssClass="span4">
                                                                                    </asp:DropDownList>
                                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_month"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        Operator="NotEqual" ValueToCompare="0" ToolTip="Select Month of Recovery"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="dd_year"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        Operator="NotEqual" ValueToCompare="0" ToolTip="Select Year of Recovery"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="30%" class="frm-lft-clr123">No. of Installments
                                                                                </td>
                                                                                <td class="frm-rght-clr123">
                                                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td width="30%">
                                                                                                <asp:TextBox ID="txt_instal_no" runat="server" CssClass="span9" size="30"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_instal_no"
                                                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                                    ToolTip="Enter No. of Installments"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_instal_no"
                                                                                                    Display="Dynamic" ErrorMessage="Enter valid instalments" MaximumValue="10000" MinimumValue="0"
                                                                                                    Type="Currency"></asp:RangeValidator>
                                                                                            </td>
                                                                                            <td width="40%">
                                                                                                <asp:Button ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="button"
                                                                                                    ToolTip="Click for Re Installments Details" Text="Calculate"></asp:Button>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="30%" class="frm-lft-clr123">Interest Amount
                                                    <br />
                                                                                    (@<asp:Label ID="lblinterestamount" runat="server"></asp:Label>%)
                                                                                </td>
                                                                                <td width="70%" class="frm-rght-clr123">Rs.&nbsp;
                                                    <asp:Label ID="lblinteresttopaid" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="30%" class="frm-lft-clr123">Monthly Amount
                                                                                </td>
                                                                                <td width="70%" class="frm-rght-clr123">Rs.&nbsp;
                                                    <asp:Label ID="lblmonthlypayment" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="30%" class="frm-lft-clr123 border-bottom">&nbsp;
                                                                                </td>
                                                                                <td width="70%" class="frm-rght-clr123 border-bottom">
                                                                                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsubmit_Click"
                                                                                        ToolTip="Click to submit the Loan & Advances Details" />
                                                                                    <asp:Button ID="btnreset" runat="server" CssClass="button" Text="Reset" OnClick="btnreset_Click"
                                                                                        ToolTip="Click to reset the entered details" ValidationGroup="none" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="2">Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                        <asp:HiddenField ID="sbi" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">&nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>



                                                    <div id="divdetail" runat="server" visible="true" align="center">

                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td>
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="95%" valign="top" class="txt02" align="left">Installment Details
                                                                            </td>
                                                                            <td width="5%" align="right" valign="top"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" align="left" valign="top">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            <%--  <table width="100%" border="1" cellspacing="0" cellpadding="3" bordercolor="#93b5c8"
                                                            style="border-collapse: collapse;">--%>
                                                                                            <tr>
                                                                                                <td colspan="3" valign="top" width="100%">
                                                                                                    <div id="divscrol" runat="server">
                                                                                                        <asp:GridView ID="detailgrid" runat="server"
                                                                                                            AutoGenerateColumns="False" EmptyDataText="No record found"
                                                                                                            PageSize="80" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="Month/Year">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("recovery") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Beginning Balance">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("beginningbalance") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Interest Payment">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("interestpayment") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Principal payment">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("principalpayment") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Ending Balance">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("endingbalance") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Total Principal">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("totalprincipal") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Total Interest">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("totalinterest") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>

                                                                                                        </asp:GridView>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td height="20" colspan="3" align="right" valign="middle">&nbsp;
                                                                                                </td>
                                                                                            </tr>

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
                                                </table>
                                            </fieldset>
                                        </div>
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
