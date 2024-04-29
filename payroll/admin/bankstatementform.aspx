<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="bankstatementform.aspx.cs"
    Inherits="payroll_admin_bankstatementform" %>

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
     <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="payroll" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                DisplayAfter="1">
                <ProgressTemplate>
                    <div class="divajax" style="left: 250px; top: 150px">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../../images/loading.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="bottom" align="center" class="txt01">
                                    Please Wait...
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
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td valign="top">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td class="blue-brdr-1" valign="top">
                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                <tbody>
                                                    <tr>
                                                       <%-- <td width="3%">
                                                            <img height="16" src="../../images/employee-icon.jpg" width="16" />
                                                        </td>--%>
                                                       <%-- <td class="txt01">
                                                            Bank Statement Form
                                                        </td>--%>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" height="20">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td class="txt02" width="27%">
                                                            View Bank Statement
                                                        </td>
                                                        <td class="txt-red" align="right" width="73%">
                                                            <span id="message" runat="server"></span>&nbsp;
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 123px" valign="top">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="25%">
                                                            Year <span class="star"></span>
                                                        </td>
                                                        <td class="frm-rght-clr123" width="75%">
                                                            <asp:DropDownList ID="dd_year" runat="server" Width="" CssClass="span4" OnDataBound="dd_year_DataBound"
                                                                DataValueField="financialyear" DataTextField="financialyear" DataSourceID="SqlDataSource12"
                                                                AutoPostBack="False">
                                                            </asp:DropDownList>
                                                            <asp:CompareValidator ID="CompareValidator12" runat="server" ValidationGroup="v"
                                                                ToolTip="Select Financial Year" ValueToCompare="0" Operator="NotEqual" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                Display="Dynamic" ControlToValidate="dd_year"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                            <asp:SqlDataSource ID="SqlDataSource12" runat="server" ProviderName="<%$ ConnectionStrings:intranetConnectionString.ProviderName %>"
                                                                SelectCommand="SELECT financial_year financialyear FROM tbl_payroll_tax_master  order by id desc"
                                                                ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"></asp:SqlDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="25%">
                                                            Month
                                                        </td>
                                                        <td class="frm-rght-clr123" width="75%">
                                                            <asp:DropDownList ID="ddlmonth" runat="server" Width="" CssClass="span4">
                                                            </asp:DropDownList>
                                                            <asp:CompareValidator ID="CompareValidator2" runat="server" ValidationGroup="v" ToolTip="Select Reimbursement"
                                                                ValueToCompare="0" Operator="NotEqual" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                Display="Dynamic" ControlToValidate="ddlmonth"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">
                                                            Branch  <span class="star"></span>
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:DropDownList ID="dd_branch" runat="server" Width="" CssClass="span4" OnDataBound="dd_branch_DataBound"
                                                                DataValueField="branch_id" DataTextField="branch_name" DataSourceID="SqlDataSourceBranch">
                                                            </asp:DropDownList>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="v" ToolTip="Select Branch"
                                                                ValueToCompare="0" Operator="NotEqual" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                Display="Dynamic" ControlToValidate="dd_branch"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                            <asp:SqlDataSource ID="SqlDataSourceBranch" runat="server" ProviderName="System.Data.SqlClient"
                                                                SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]"
                                                                ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"></asp:SqlDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="25%">
                                                            Type
                                                        </td>
                                                        <td class="frm-rght-clr123" width="75%">
                                                            <asp:DropDownList ID="ddl_reimbursement_type" runat="server" Width="" CssClass="span4">
                                                                <asp:ListItem Value="0">Salary</asp:ListItem>
                                                                <asp:ListItem Value="1">Reimbursement</asp:ListItem>
                                                                <asp:ListItem Value="2">Bonus</asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="25%">
                                                            Bank Name  <span class="star"></span>
                                                        </td>
                                                        <td class="frm-rght-clr123" width="75%">
                                                            <asp:DropDownList ID="ddl_bank_name" runat="server" Width="" CssClass="span4"
                                                                OnDataBound="ddl_bank_name_DataBound" DataValueField="branchcode" DataTextField="bankname"
                                                                DataSourceID="SqlDataSource1">
                                                            </asp:DropDownList>
                                                            <asp:CompareValidator ID="CompareValidator11" runat="server" ValidationGroup="v"
                                                                ToolTip="Select  Bank Name" ValueToCompare="0" Operator="NotEqual" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                ControlToValidate="ddl_bank_name" SetFocusOnError="True"></asp:CompareValidator>
                                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ProviderName="System.Data.SqlClient"
                                                                SelectCommand="SELECT [branchcode],[branchcode]+'--'+[bankname] as bankname FROM tbl_payroll_bank"
                                                                ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"></asp:SqlDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 border-bottom" width="25%">
                                                            &nbsp;
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom" width="75%">
                                                            <asp:Button ID="btnsbmit" OnClick="btnsbmit_Click" runat="server" CssClass="button"
                                                                ValidationGroup="v" ToolTip="Click to submit the created Reimbursement" Text="Submit">
                                                            </asp:Button>&nbsp;
                                                            <asp:Button ID="btn_reset" OnClick="btn_reset_Click" runat="server" CssClass="button"
                                                                Text="Reset"></asp:Button>
                                                            <asp:Button ID="btnexport" runat="server" CssClass="button" Text="Export" OnClick="btnexport_Click"
                                                                ValidationGroup="v"></asp:Button>
                                                        </td>
                                                    </tr>
                                               <%--     <tr>
                                                        <td align="left" colspan="2">
                                                            Mandatory Fields (<img alt="" src="../../images/error1.gif" />)
                                                        </td>
                                                    </tr>--%>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" height="20">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td class="txt02" width="27%">
                                                            <br />
                                                            Bank Statement Details
                                                        </td>
                                                        <td class="txt-red" align="right" width="73%">
                                                            <span id="SPAN1" runat="server"></span>&nbsp;
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 123px" valign="top">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td >
                                                           
                                                            <asp:Label ID="lblmonth" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td >
                                                            <asp:Label ID="lblbankname" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%"><div class="widget-content">
                                                            <asp:GridView ID="bankgrid" runat="server"  OnPageIndexChanging="bankgrid_PageIndexChanging"
                                                                EmptyDataText="Sorry No Records Found" PageSize="15" AllowPaging="true" 
                                                                DataKeyNames=""
                                                                AutoGenerateColumns="false" CssClass ="table table-hover table-striped table-bordered table-highlight-head">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Employee Name">
                                                                       
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind("empname")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Account Number">
                                                                       
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("acno")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Total Amount">
                                                                       
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("totamount")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                              
                                                            </asp:GridView></div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
                   </fieldset>
                   </div>
                   </div>
                   </div>
                   </div>
                   </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnexport" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
