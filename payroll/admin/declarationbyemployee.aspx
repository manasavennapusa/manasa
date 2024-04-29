<%@ Page Language="C#" AutoEventWireup="true" CodeFile="declarationbyemployee.aspx.cs" Inherits="payroll_admin_declarationbyemployee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
        @import "../../css/example.css";
        @import "../../css/ajax__tab_xp2.css";

        .star:before
        {
            content: " *";
        }
    </style>
    <link href="../../css/main.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/tabber.js"></script>

    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>

    <script src="../../leave/js/popup.js"></script>
    <script src="../../js/JavaScriptValidations.js"></script>
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
                <div class="dashboard-wrapper" style="margin-left: 0px;">
                    <div class="main-container">
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">

                                    <div class="widget-body">
                                        <fieldset>
                                            <div id="declare">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td valign="top" class="blue-brdr-1">
                                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <%-- <td width="3%">
                                            <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                        </td>--%>
                                                                    <td class="txt01">Employee Tax Calculation Form
                                                                    </td>
                                                                    <td width="70%" align="right" class="txt-red">
                                                                        <span id="message" runat="server"></span>&nbsp;
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
                                                                    <td width="20%" class="frm-lft-clr123">Employee Code <span class="star"></span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="3">
                                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td width="60%">
                                                                                    <asp:TextBox ID="txt_employee" size="30" CssClass="span4" runat="server" ToolTip="Employee Code"
                                                                                        onkeypress="return enterdate(event);" onkeydown="return enterdate(event);" Enabled="false"></asp:TextBox>

                                                                                </td>

                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">Financial Year
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="3">
                                                                        <asp:DropDownList ID="lbl_fyear" runat="server" CssClass="span4"></asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" colspan="5">House Property Details
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">Self Occupied
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="3">
                                                                        <asp:RadioButton ID="opt_self_yes" runat="server" Text="Yes" Checked="True" GroupName="a" />
                                                                        <asp:RadioButton ID="opt_self_no" runat="server" GroupName="a" Text="No" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">Loan Borrowed
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom" style="border-right: none">
                                                                        <asp:RadioButton ID="opt_loan_yes" runat="server" GroupName="b" Text="Yes" OnCheckedChanged="opt_loan_yes_CheckedChanged"
                                                                            AutoPostBack="true" />
                                                                        <asp:RadioButton ID="opt_loan_no" runat="server" GroupName="b" Text="No" AutoPostBack="True"
                                                                            OnCheckedChanged="opt_loan_no_CheckedChanged" Checked="True" />
                                                                    </td>
                                                                    <td class="frm-lft-clr123 border-bottom" width="20%">Interest
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom" width="30%">
                                                                        <asp:TextBox ID="txt_houseint" size="20" CssClass="span9" runat="server" AutoPostBack="True"
                                                                            Enabled="False"></asp:TextBox>
                                                                        <asp:RangeValidator ID="RangeValidator27" runat="server" ControlToValidate="txt_houseint"
                                                                            ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                            Type="Currency" ValidationGroup="s"><img src="../../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">Uniform Reimbursement
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom" style="border-right: none">
                                                                        <asp:TextBox ID="txt_medical_bil" size="20" CssClass="span9" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="frm-lft-clr123 border-bottom" width="20%">Telephone Reimbursement
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom" width="30%">
                                                                        <asp:TextBox ID="txt_LTA" size="20" CssClass="span9" runat="server"></asp:TextBox>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="20"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <%-- :::::::::::::::::::::::::::::::::::::: Declaration Tabs ::::::::::::::::::::::::::::::::::::::::: --%>
                                                    <tr>
                                                        <td colspan="2">
                                                            <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%"
                                                                CssClass="ajax__tab_xp2">
                                                                <cc1:TabPanel ID="Tab_rent" runat="server" HeaderText="Rent Paid Details">
                                                                    <ContentTemplate>
                                                                        <div>
                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" class="txt02" style="height: 13px">Rent Detail
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top">
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td colspan="9">
                                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123" width="24%">Metro/Non-metro City
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123" colspan="8" width="76%">
                                                                                                                <asp:DropDownList ID="dd_metro" runat="server" CssClass="span4">
                                                                                                                    <asp:ListItem Value="1" Selected="True">Metro</asp:ListItem>
                                                                                                                    <asp:ListItem Value="0">Non-metro</asp:ListItem>
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td height="5" colspan="9" class=" frm-rght-clr123" style="border-right: 1px solid #ddd;">
                                                                                                    <asp:RadioButton ID="rdoyearly" runat="server" Text="Yearly" AutoPostBack="True"
                                                                                                        GroupName="rent" OnCheckedChanged="rdoyearly_CheckedChanged" Checked="True" /><asp:RadioButton
                                                                                                            ID="rdomonthly" runat="server" Text="Monthly" AutoPostBack="True" GroupName="rent"
                                                                                                            OnCheckedChanged="rdomonthly_CheckedChanged" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="9">
                                                                                                    <div id="monthly" runat="server" visible="False">
                                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                            <tr>
                                                                                                                <td class="frm-lft-clr123" width="15%">April
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123" colspan="2" width="18%" style="border-right: none">
                                                                                                                    <asp:TextBox ID="txt_apr" runat="server" CssClass="span8" Width=""></asp:TextBox>
                                                                                                                    <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txt_apr"
                                                                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                                                                        Type="Currency" ValidationGroup="s"><img src="../../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                                                                </td>
                                                                                                                <td class="frm-lft-clr123" width="15%">May
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123" colspan="2" width="18%" style="border-right: none">
                                                                                                                    <asp:TextBox ID="txt_may" runat="server" CssClass="span8" Width=""></asp:TextBox>
                                                                                                                    <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txt_may"
                                                                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                                                                        Type="Currency" ValidationGroup="s"><img src="../../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                                                                </td>
                                                                                                                <td class="frm-lft-clr123" width="15%">June
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123" colspan="2" width="18%">
                                                                                                                    <asp:TextBox ID="txt_june" runat="server" CssClass="span8" Width=""></asp:TextBox>
                                                                                                                    <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txt_june"
                                                                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                                                                        Type="Currency" ValidationGroup="s"><img src="../../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="frm-lft-clr123">July
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123" colspan="2" style="border-right: none">
                                                                                                                    <asp:TextBox ID="txt_jul" runat="server" CssClass="span8" Width=""></asp:TextBox>
                                                                                                                    <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txt_jul"
                                                                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                                                                        Type="Currency" ValidationGroup="s"><img src="../../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                                                                </td>
                                                                                                                <td class="frm-lft-clr123">August
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123" colspan="2" style="border-right: none">
                                                                                                                    <asp:TextBox ID="txt_aug" runat="server" CssClass="span8" Width=""></asp:TextBox>
                                                                                                                    <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txt_aug"
                                                                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                                                                        Type="Currency" ValidationGroup="s"><img src="../../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                                                                </td>
                                                                                                                <td class="frm-lft-clr123">September
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123" colspan="2">
                                                                                                                    <asp:TextBox ID="txt_sep" runat="server" CssClass="span8" Width=""></asp:TextBox>
                                                                                                                    <asp:RangeValidator ID="RangeValidator8" runat="server" ControlToValidate="txt_sep"
                                                                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                                                                        Type="Currency" ValidationGroup="s"><img src="../../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="frm-lft-clr123">October
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123" colspan="2" style="border-right: none">
                                                                                                                    <asp:TextBox ID="txt_oct" runat="server" CssClass="span8" Width=""></asp:TextBox>
                                                                                                                    <asp:RangeValidator ID="RangeValidator9" runat="server" ControlToValidate="txt_oct"
                                                                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                                                                        Type="Currency" ValidationGroup="s"><img src="../../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                                                                </td>
                                                                                                                <td class="frm-lft-clr123">November
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123" colspan="2" style="border-right: none">
                                                                                                                    <asp:TextBox ID="txt_nov" runat="server" CssClass="span8" Width=""></asp:TextBox>
                                                                                                                    <asp:RangeValidator ID="RangeValidator10" runat="server" ControlToValidate="txt_nov"
                                                                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                                                                        Type="Currency" ValidationGroup="s"><img src="../../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                                                                </td>
                                                                                                                <td class="frm-lft-clr123">December
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123" colspan="2">
                                                                                                                    <asp:TextBox ID="txt_dec" runat="server" CssClass="span8" Width=""></asp:TextBox>
                                                                                                                    <asp:RangeValidator ID="RangeValidator11" runat="server" ControlToValidate="txt_dec"
                                                                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                                                                        Type="Currency" ValidationGroup="s"><img src="../../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="frm-lft-clr123 border-bottom">January
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123 border-bottom" colspan="2" style="border-right: none">
                                                                                                                    <asp:TextBox ID="txt_jan" runat="server" CssClass="span8" Width=""></asp:TextBox>
                                                                                                                    <asp:RangeValidator ID="RangeValidator12" runat="server" ControlToValidate="txt_jan"
                                                                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                                                                        Type="Currency" ValidationGroup="s"><img src="../../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                                                                </td>
                                                                                                                <td class="frm-lft-clr123 border-bottom">February
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123 border-bottom" colspan="2" style="border-right: none">
                                                                                                                    <asp:TextBox ID="txt_feb" runat="server" CssClass="span8" Width=""></asp:TextBox>
                                                                                                                    <asp:RangeValidator ID="RangeValidator13" runat="server" ControlToValidate="txt_feb"
                                                                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                                                                        Type="Currency" ValidationGroup="s"><img src="../../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                                                                </td>
                                                                                                                <td class="frm-lft-clr123 border-bottom">March
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123 border-bottom" colspan="2">
                                                                                                                    <asp:TextBox ID="txt_mar" runat="server" CssClass="span8" Width=""></asp:TextBox>
                                                                                                                    <asp:RangeValidator ID="RangeValidator14" runat="server" ControlToValidate="txt_mar"
                                                                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                                                                        Type="Currency" ValidationGroup="s"><img src="../../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td height="5" colspan="9">
                                                                                                    <div id="yearly" runat="server">
                                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                            <tr>
                                                                                                                <td class="frm-lft-clr123" width="30%">From
                                                                                                                </td>
                                                                                                                <td class="frm-lft-clr123" width="30%">To
                                                                                                                </td>
                                                                                                                <td class="frm-lft-clr123 " width="40%" style="border-right: 1px solid #ddd;">Per Year
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="frm-rght-clr123 border-bottom" width="30%" style="border-right: none">1 Apr
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123 border-bottom" width="30%" style="border-right: none">31 Mar
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123 border-bottom" width="40%">
                                                                                                                    <asp:TextBox ID="txt_mth" runat="server" CssClass="span7" Width=""></asp:TextBox>
                                                                                                                    <asp:RangeValidator ID="RangeValidator28" runat="server" ControlToValidate="txt_mth"
                                                                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                                                                        Type="Currency" ValidationGroup="s"><img src="../../images/error1.gif" alt="Enter correct amount" /></asp:RangeValidator>
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
                                                                                    <td colspan="2" class="txt02" style="height: 13px">Children Detail
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" style="height: 5px"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom" width="24%">No. of Children
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom" colspan="8" width="76%">
                                                                                                    <asp:TextBox ID="txt_child" runat="server" CssClass="span4" Width=""></asp:TextBox>
                                                                                                    <asp:RangeValidator ID="RangeValidator29" runat="server" ControlToValidate="txt_child"
                                                                                                        ErrorMessage="RangeValidator" MaximumValue="2" MinimumValue="0" ToolTip="Can not exceed 2"
                                                                                                        Type="Integer" ValidationGroup="s"><img src="../../images/error1.gif" alt="Enter number" /></asp:RangeValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                    <HeaderTemplate>
                                                                        Rent Paid/Children Details
                                                                    </HeaderTemplate>
                                                                </cc1:TabPanel>
                                                                <cc1:TabPanel ID="Tab_6Adetail" runat="server" HeaderText="VI-A Deduction">
                                                                    <ContentTemplate>
                                                                        <div>
                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" class="txt02">VI-A Deduction
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="100%" colspan="2" class="head-2">
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom" width="25%">Section
                                                                                                </td>
                                                                                                <td class="frm-lft-clr123 border-bottom" width="30%">Detail
                                                                                                </td>
                                                                                                <td class="frm-lft-clr123 border-bottom" width="30%">Amount
                                                                                                </td>
                                                                                                <td class="frm-lft-clr123 border-bottom" width="15%">&nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-rght-clr1234">
                                                                                                    <asp:DropDownList ID="dd_smaster" runat="server" CssClass="span10" Width="" DataSourceID="SqlDataSource1"
                                                                                                        DataTextField="sname" DataValueField="sname" AutoPostBack="True" AppendDataBoundItems="True">
                                                                                                        <asp:ListItem Value="0">Select One</asp:ListItem>
                                                                                                    </asp:DropDownList>
                                                                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="dd_smaster"
                                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="Enter amount" />'
                                                                                                        Operator="NotEqual" ToolTip="Select Section" ValueToCompare="0" ValidationGroup="c"></asp:CompareValidator>
                                                                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                        SelectCommand="select sname from tbl_payroll_sectionmaster" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr1234">&nbsp;<asp:DropDownList ID="dd_sdetail" runat="server" CssClass="span8" Width=""
                                                                                                    DataSourceID="SqlDataSource2" DataTextField="section_detail" DataValueField="section_detail"
                                                                                                    OnDataBound="dd_sdetail_DataBound">
                                                                                                </asp:DropDownList>
                                                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_sdetail"
                                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                                        Operator="NotEqual" ToolTip="Select Section Detail" ValueToCompare="0" ValidationGroup="c"></asp:CompareValidator>
                                                                                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                        SelectCommand="select section_detail from tbl_payroll_sectiondetail&#13;&#10;where section_name=@sname"
                                                                                                        ProviderName="System.Data.SqlClient">
                                                                                                        <SelectParameters>
                                                                                                            <asp:ControlParameter ControlID="dd_smaster" DefaultValue="" Name="sname" PropertyName="SelectedValue"
                                                                                                                Type="String" />
                                                                                                        </SelectParameters>
                                                                                                    </asp:SqlDataSource>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr1234">
                                                                                                    <asp:TextBox ID="txt_samnt" runat="server" CssClass="span8"></asp:TextBox>
                                                                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_samnt"
                                                                                                        ErrorMessage='<img src="../../images/error1.gif" alt="Enter amount" />' MaximumValue="9999999"
                                                                                                        MinimumValue="0" ToolTip="Enter valid amount" Type="Currency" ValidationGroup="c"
                                                                                                        Display="Dynamic"><img src="../../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_samnt"
                                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="Enter amount" />'
                                                                                                        ToolTip="Enter Amount" ValidationGroup="c"><img src="../../images/error1.gif" alt="Enter amount" /></asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr1234">
                                                                                                    <asp:Button ID="btn_6A_add" runat="server" Text="Add" CssClass="button" OnClick="btn_6A_add_Click"
                                                                                                        ValidationGroup="c" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="10" valign="top" colspan="2">
                                                                                        <asp:GridView ID="grid_6A"
                                                                                            runat="server"
                                                                                            AutoGenerateColumns="False"
                                                                                            DataKeyNames="section_detail"
                                                                                            EmptyDataText="No record found"
                                                                                            OnRowDeleting="grid_6A_RowDeleting"
                                                                                            CssClass="table table-condensed table-striped table-hover table-bordered pull-left">
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Status">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:CheckBox ID="chkstatus" runat="server" Checked="true"></asp:CheckBox>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Section">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="kck" runat="server" Text='<%# Bind("section_name")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Detail">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="pck" runat="server" Text='<%# Bind("section_detail")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="acl" runat="server" Text='<%# Bind("a_amount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField>

                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete"
                                                                                                            CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>

                                                                                        </asp:GridView>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </cc1:TabPanel>

                                                                <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Previous Employment Salary">
                                                                    <ContentTemplate>
                                                                        <div>
                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" class="txt02">Previous Employment Salary
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="100%" colspan="2" class="head-2">
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom" width="25%">Income after Section 10 Exemption
                                                                                                </td>
                                                                                                <td class="frm-lft-clr123 border-bottom">
                                                                                                    <asp:TextBox ID="txt_Income" runat="server" CssClass="span8"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom" width="25%">Professional Tax Paid
                                                                                                </td>
                                                                                                <td class="frm-lft-clr123 border-bottom">
                                                                                                    <asp:TextBox ID="txt_prof_tax" runat="server" CssClass="span8"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom" width="25%">Provident Fund Paid
                                                                                                </td>
                                                                                                <td class="frm-lft-clr123 border-bottom">
                                                                                                    <asp:TextBox ID="txt_fund_paid" runat="server" CssClass="span8"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom" width="25%">Income Tax Paid
                                                                                                </td>
                                                                                                <td class="frm-lft-clr123 border-bottom">
                                                                                                    <asp:TextBox ID="txt_tax_paid" runat="server" CssClass="span8"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>

                                                                            </table>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </cc1:TabPanel>

                                                                <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Let Out Property">
                                                                    <ContentTemplate>
                                                                        <div>
                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" class="txt02">Let Out Property
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="100%" colspan="2" class="head-2">
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom" width="25%">Rent Received
                                                                                                </td>
                                                                                                <td class="frm-lft-clr123 border-bottom">
                                                                                                    <asp:TextBox ID="txt_rent" runat="server" CssClass="span8"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom" width="25%">Less Municipal Taxes Paid
                                                                                                </td>
                                                                                                <td class="frm-lft-clr123 border-bottom">
                                                                                                    <asp:TextBox ID="txt_less_tax" runat="server" CssClass="span8"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom" width="25%">Interest on Housing Property
                                                                                                </td>
                                                                                                <td class="frm-lft-clr123 border-bottom">
                                                                                                    <asp:TextBox ID="txt_housing" runat="server" CssClass="span8"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </cc1:TabPanel>
                                                                <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Upload HRA Reciept">
                                                                    <ContentTemplate>
                                                                        <div>
                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" class="txt02"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="100%" colspan="2" class="head-2">
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom" width="25%">HRA Reciept 
                                                                                                </td>
                                                                                                <td class="frm-lft-clr123 border-bottom">
                                                                                                    <asp:FileUpload ID="flupload" runat="server" />
                                                                                                </td>
                                                                                            </tr>


                                                                                        </table>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </cc1:TabPanel>
                                                            </cc1:TabContainer>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5" colspan="2"></td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td align="right">
                                                                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsubmit_Click"
                                                                            ToolTip="Click to submit the Declaration" />
                                                                        <asp:Button ID="btnreset" runat="server" CssClass="button" Text="Reset" OnClick="btnreset_Click"
                                                                            ToolTip="Click to reset the entered details" ValidationGroup="none" />
                                                                    </td>
                                                                </tr>
                                                                <%-- <tr>
                                        <td align="left" colspan="2">Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                        </td>
                                    </tr>--%>
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
              <Triggers>
                <asp:PostBackTrigger ControlID="btnsubmit" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
