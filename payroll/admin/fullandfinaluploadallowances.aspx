<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fullandfinaluploadallowances.aspx.cs" Inherits="payroll_admin_fullandfinaluploadallowances" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";

        .star:before
        {
            content: " *";
        }
    </style>
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
    <script src="../../leave/js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--<asp:ScriptManager ID="bank" runat="server">
</asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax"><table width="100%"><tr><td align="center" valign="top"><img src="../../images/loading.gif" /></td><td valign="bottom">Please Wait...</td></tr></table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">

                            <div class="widget-body">
                                <fieldset>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="top" height="463px">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td valign="top" class="blue-brdr-1">
                                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <%-- <td width="3%" style="height: 16px">
                                        <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                    </td>--%>
                                                                    <td class="txt01" style="height: 16px">Employee Allowances
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5" valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" style="height: 5px">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="14%">Employee Code  <span class="star"></span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="15%">
                                                                        <asp:TextBox ID="txt_employee" size="40" CssClass="span10" runat="server" Width="50%" ToolTip="Employee Code" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);" AutoPostBack="true"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <a href="JavaScript:newPopup1('../../leave/pickemployeefullnfinal.aspx');" class="link05">Pick Employee</a>

                                                                    </td>

                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="14%">Financial Year  <span class="star"></span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="10%">
                                                                        <asp:DropDownList ID="dd_year" runat="server" AutoPostBack="False" DataSourceID="SqlDataSource12"
                                                                            DataTextField="financialyear" DataValueField="financialyear" OnDataBound="dd_year_DataBound"
                                                                            CssClass="span10" Width="">
                                                                        </asp:DropDownList>
                                                                        <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="dd_year"
                                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                            Operator="NotEqual" ValueToCompare="0" ToolTip="Select Financial Year" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                        <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                            SelectCommand="select  [financial_year] as financialyear from tbl_payroll_tax_master order by id desc"
                                                                            ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" width="14%">Month
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="3">
                                                                        <asp:DropDownList ID="dd_month" runat="server" CssClass="span8" DataTextField="month "
                                                                            DataValueField="month " ToolTip="Month" Width="">
                                                                                    <asp:ListItem Value="1">Jan</asp:ListItem>
                                                                                    <asp:ListItem Value="2">Feb</asp:ListItem>
                                                                                    <asp:ListItem Value="3">Mar</asp:ListItem>
                                                                                    <asp:ListItem Value="4">Apr</asp:ListItem>
                                                                                    <asp:ListItem Value="5">May</asp:ListItem>
                                                                                    <asp:ListItem Value="6">Jun</asp:ListItem>
                                                                                    <asp:ListItem Value="7">Jul</asp:ListItem>
                                                                                    <asp:ListItem Value="8">Aug</asp:ListItem>
                                                                                    <asp:ListItem Value="9">Sep</asp:ListItem>
                                                                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                                                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                                                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="reqPayHead" runat="server" ControlToValidate="dd_month"
                                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                            ToolTip="Select Month" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="frm-lft-clr123   border-bottom" width="14%">Allowance <span class="star"></span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123  border-bottom" width="15%">
                                                                        <asp:DropDownList ID="drpPayHead" runat="server" CssClass="span10" ToolTip="Pay Head"
                                                                            Width="" OnDataBound="drpPayHead_DataBound">
                                                                        </asp:DropDownList>
                                                                        <asp:CompareValidator ID="CompareValidator111" runat="server" ControlToValidate="drpPayHead"
                                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                            Operator="NotEqual" ValueToCompare="0" ToolTip="Select Financial Year" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                    </td>
                                                                    <td class="frm-lft-clr123 border-bottom" width="14%">Amount
                                                                    </td>
                                                                    <td class="frm-rght-clr123  border-bottom" colspan="3" width="20%">
                                                                        <asp:TextBox ID="txtamount" runat="server" CssClass="span8"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="top" style="height: 5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5" align="right" valign="top">
                                                            <asp:Button ID="btn_view" runat="server" CssClass="button" OnClick="btn_view_Click"
                                                                Text="Submit" ValidationGroup="v" />
                                                           <asp:Button ID="btn_view1" runat="server" CssClass="button" OnClick="btn_view1_Click"
                                                                Text="View" ValidationGroup="v" />
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
                                                                                <td width="27%" class="txt02" style="height: 13px">Allowance Detail
                                                                                </td>
                                                                                <td width="73%" align="right" class="txt-red" style="height: 13px">
                                                                                    <span id="message" runat="server"></span>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="head-2" valign="top">
                                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                                                                                    runat="server">
                                                                                    <ProgressTemplate>
                                                                                        <div class="divajax" style="top: 160px;">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td align="center" valign="top">
                                                                                                        <img alt="" src="../../images/loading.gif" />
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
                                                                                <asp:GridView ID="adjustgrid" runat="server"
                                                                                    AutoGenerateColumns="False" EmptyDataText=""
                                                                                    DataKeyNames="empcode,allowanceid,month,year" AllowPaging="True" OnPageIndexChanging="adjustgrid_PageIndexChanging"
                                                                                    PageSize="40" AllowSorting="True" OnSorting="adjustgrid_Sorting">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Financial Year">

                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="l2" runat="server" Text='<%# Bind ("year") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Emp Code" SortExpression="empcode">

                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="l2" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Emp Name" SortExpression="empname">

                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Allowance">

                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="l4" runat="server" Text='<%# Bind ("allowancename") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Amount">

                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="l5" runat="server" Text='<%# Bind ("amount") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>

                                                                                    <%-- <PagerSettings Position="TopAndBottom" />--%>
                                                                                </asp:GridView>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
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
        <%--</ContentTemplate>
</asp:UpdatePanel>--%>
    </form>
</body>
</html>
