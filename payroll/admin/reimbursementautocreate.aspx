<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reimbursementautocreate.aspx.cs"
    Inherits="payroll_admin_reimbursementautocreate" %>

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
     <link href="../../js/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../js/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="payroll" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="divajax">
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
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td valign="top">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td class="blue-brdr-1" valign="top">
                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                        <tr>
                                      <%--      <td width="3%">
                                                <img height="16" src="../../images/employee-icon.jpg" width="16" />
                                            </td>--%>
                                            <%--<td class="txt01">
                                                Auto Create Reimbursement Master
                                            </td>--%>
                                        </tr>
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
                                        <tr>
                                            <td class="txt02" width="27%">
                                                Auto Create Reimbursement
                                            </td>
                                            <td class="txt-red" align="right" width="73%">
                                                <span id="message" runat="server"></span>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 123px" valign="top">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td class="frm-lft-clr123" width="25%">
                                                Year <span class="star"></span>
                                            </td>
                                            <td class="frm-rght-clr123" width="75%">
                                                <asp:DropDownList ID="dd_year" runat="server" AutoPostBack="False" DataSourceID="SqlDataSource12"
                                                    DataTextField="financialyear" DataValueField="financialyear" OnDataBound="dd_year_DataBound"
                                                    CssClass="blue1" Width="180px">
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
                                            <td class="frm-lft-clr123" width="25%">
                                                Reimbursement <span class="star"></span>
                                            </td>
                                            <td class="frm-rght-clr123" width="75%">
                                                <asp:DropDownList ID="ddlreimbursement" runat="server" CssClass="blue1" Width="180px"
                                                    DataSourceID="SqlDataSource1" DataTextField="PAYHEAD_NAME" DataValueField="id"
                                                    OnDataBound="ddlreimbursement_DataBound" AutoPostBack="True" OnSelectedIndexChanged="ddlreimbursement_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlreimbursement"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    Operator="NotEqual" ValueToCompare="0" ToolTip="Select Reimbursement" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    SelectCommand="select [id],[PAYHEAD_NAME] from tbl_payroll_reimbursement" ProviderName="System.Data.SqlClient">
                                                </asp:SqlDataSource>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                Branch <span class="star"></span>
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:DropDownList ID="dd_branch" runat="server" CssClass="blue1" DataSourceID="SqlDataSourceBranch"
                                                    DataTextField="branch_name" DataValueField="branch_id" OnDataBound="dd_branch_DataBound"
                                                    Width="180px">
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_branch"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    Operator="NotEqual" ToolTip="Select Branch" ValidationGroup="v" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                <asp:SqlDataSource ID="SqlDataSourceBranch" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]"
                                                    ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" width="25%">
                                                Amount
                                            </td>
                                            <td class="frm-rght-clr123" width="75%">
                                                &nbsp;<asp:Label ID="txtamount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123 border-bottom" width="25%">
                                                &nbsp;
                                            </td>
                                            <td class="frm-rght-clr123 border-bottom" width="75%">
                                                <asp:Button ID="btnsbmit" OnClick="btnsbmit_Click" runat="server" ToolTip="Click to submit the created Reimbursement"
                                                    CssClass="button" ValidationGroup="v" Text="Submit"></asp:Button>&nbsp;
                                                <asp:Button ID="btn_reset" OnClick="btn_reset_Click" runat="server" CssClass="button"
                                                    Text="Reset"></asp:Button>
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td align="left" colspan="2">
                                                Mandatory Fields (<img alt="" src="../../images/error1.gif" />)
                                            </td>
                                        </tr>--%>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top"><div class="widget-content">
                                    <asp:GridView ID="reimbursementgird" runat="server" 
                                        CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"
                                        EmptyDataText="Sorry no record found" AllowPaging="True" PageSize="30" OnPageIndexChanging="reimbursementgird_PageIndexChanging"
                                        OnRowEditing="reimbursementgird_RowEditing" OnRowCancelingEdit="reimbursementgird_RowCancelingEdit"
                                        OnRowUpdating="reimbursementgird_RowUpdating" CssClass ="table table-hover table-striped table-bordered table-highlight-head">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Financial Year">
                                               <ItemTemplate>
                                                    <asp:Label ID="lblfinancialyear" runat="server" Text='<%# Bind ("financialyear") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reimbursement Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblreimbursementname" runat="server" Text='<%# Bind ("reimbursementname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempcode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblamount" runat="server" Text='<%# Bind ("amount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtamountg" runat="server" Text='<%# Bind ("amount") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                               <ItemTemplate>
                                                    <asp:LinkButton ID="btnedit" runat="Server" CommandName="Edit" Text="Edit" CssClass="link05"></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="Button3" runat="Server" CommandName="Update" Text="Update" CssClass="link05"
                                                        OnClientClick="return confirm(' Do you want to Update this record?');" />
                                                    |
                                                    <asp:LinkButton ID="Button4" runat="Server" CommandName="Cancel" Text="Cancel" CssClass="link05" />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                       
                                    </asp:GridView></div>
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
