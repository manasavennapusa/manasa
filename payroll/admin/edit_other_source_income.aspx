<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_other_source_income.aspx.cs"
    Inherits="payroll_admin_edit_other_source_income" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartDrive Labs Technologies India Pvt. Ltd. :: Other Source Income</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
    <script src="../../leave/js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="leave" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax">
                <table width="100%">
                <tr>
                <td align="center" valign="top"><img src="../../images/loading.gif" /></td>
                </tr>
                <tr>
                <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                </tr>
                </table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
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
                                            <td class="txt01">
                                                Other Source Income &nbsp;Master
                                            </td>
                                        </tr>
                                    </table>
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
                                                Other Source Income
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
                                                Emp Code
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:TextBox ID="txt_employee" size="40" CssClass="blue1" runat="server" ToolTip="Employee Code"
                                                    Width="88px" Enabled="False"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"
                                                    ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Financial Year
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:DropDownList ID="dd_year" runat="server" DataSourceID="SqlDataSource12" DataTextField="financialyear"
                                                    DataValueField="financialyear" OnDataBound="dd_year_DataBound" CssClass="blue1"
                                                    Width="163px">
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="dd_year"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    Operator="NotEqual" ValueToCompare="0" ToolTip="Select Financial Year" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    SelectCommand="select distinct [financial_year] as financialyear from tbl_payroll_tax_master"
                                                    ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Income Source
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:DropDownList ID="ddlincomesource" runat="server" Width="168px" DataSourceID="SqlDataSource1"
                                                    DataTextField="incomesource" DataValueField="id" CssClass="blue1">
                                                </asp:DropDownList>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    SelectCommand="select id,incomesource from tbl_payroll_income_source_master"
                                                    ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Amount
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                &nbsp;<asp:TextBox ID="txtamount" runat="server" Width="129px" CssClass="blue1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ToolTip="Enter Employee Code"
                                                    Display="Dynamic" ValidationGroup="v" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    ControlToValidate="txtamount"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123 border-bottom">
                                                &nbsp;
                                            </td>
                                            <td width="75%" class="frm-rght-clr123 border-bottom">
                                                <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                    ValidationGroup="v" ToolTip="Click to submit the created leave" />&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
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
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
