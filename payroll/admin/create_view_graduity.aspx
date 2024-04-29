<%@ Page Language="C#" AutoEventWireup="true" CodeFile="create_view_graduity.aspx.cs"
    Inherits="payroll_admin_create_view_graduity" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
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
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
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
                                                Gratuity Master
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
                                                Create Gratuity
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
                                                Financial Year
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:DropDownList ID="dd_year" runat="server" AutoPostBack="False" DataSourceID="SqlDataSource12"
                                                    DataTextField="financialyear" DataValueField="financialyear" CssClass="blue1"
                                                    Width="145px">
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="dd_year"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    Operator="NotEqual" ValueToCompare="0" ToolTip="Select Financial Year" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>&nbsp;
                                                <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    SelectCommand="select distinct [financial_year] as financialyear from tbl_payroll_tax_master"
                                                    ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Date
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:TextBox ID="txtdate" runat="server" CssClass="blue1" Width="100px" Enabled="False"></asp:TextBox>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                                <asp:RequiredFieldValidator ID="rfvsdate" runat="server" ControlToValidate="txtdate"
                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                    ToolTip="Select  Date" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                    TargetControlID="txtdate" Format="MM/dd/yyyy">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123 border-bottom">
                                                &nbsp;
                                            </td>
                                            <td width="75%" class="frm-rght-clr123 border-bottom">
                                                <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                    ValidationGroup="v" ToolTip="Click to submit the created Payhead" />&nbsp;
                                                <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="View" OnClick="btn_reset_Click" />&nbsp;<asp:Button
                                                    ID="btnexport" runat="server" CssClass="button" OnClick="btnexport_Click" Text="Export" />
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
                                <td>
                                    <div id="graduityview" runat="server" visible="false">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="txt02">
                                                    Gratuity View
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr class="frm-lft-clr123">
                                                <td>
                                                    Gratuity Amount : Rs.
                                                    <asp:Label ID="lblgraduityamt" runat="server" Text=""></asp:Label>
                                                    | Gratuity date :
                                                    <asp:Label ID="lblgraduitydate" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                        CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                        BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="No such employee exists !"
                                                        OnPageIndexChanging="empgrid_PageIndexChanging" CssClass="gvclass" Border="1px solid #ddd">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Emp Code">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Employee Name">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Width="22%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("emp_name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="DOJ">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("emp_doj") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Dept name">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Width="14%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Branch Name">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("gratuity_amt") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                        <RowStyle Height="5px" />
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
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnexport" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
