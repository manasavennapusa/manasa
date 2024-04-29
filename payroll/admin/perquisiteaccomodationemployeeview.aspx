<%@ Page Language="C#" AutoEventWireup="true" CodeFile="perquisiteaccomodationemployeeview.aspx.cs"
    Inherits="payroll_admin_perquisiteaccomodationemployeeview" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="payroll" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--<asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">
            <ProgressTemplate>
                <div class="divajax" style="left: 250px; top: 150px">
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
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td valign="top">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td class="blue-brdr-1" valign="top">
                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                        <tr>
                                            <td width="3%">
                                                <img height="16" src="../../images/employee-icon.jpg" width="16" />
                                            </td>
                                            <td class="txt01">
                                                Employee Perquisite master
                                            </td>
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
                                                Entry Employee Perquisite
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
                                                Employee Code
                                            </td>
                                            <td class="frm-rght-clr123" width="75%">
                                                &nbsp;<asp:Label ID="txt_employee" runat="server"></asp:Label>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                Lease From
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:TextBox ID="txtleasefrom" runat="server" CssClass="blue1" size="40" ToolTip="Lease From"
                                                    Width="88px"></asp:TextBox>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                                <asp:RequiredFieldValidator ID="rfvsdate" runat="server" ControlToValidate="txtleasefrom"
                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                    ToolTip="Select Loan Sanction Date" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                    TargetControlID="txtleasefrom" Format="MM/dd/yyyy">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                Lease To
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:TextBox ID="txtleaseto" runat="server" CssClass="blue1" size="40" ToolTip="Lease To"
                                                    Width="88px"></asp:TextBox>
                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/clndr.gif" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtleaseto"
                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                    ToolTip="Select Loan Sanction Date" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="Image2"
                                                    TargetControlID="txtleaseto" Format="MM/dd/yyyy">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                &nbsp;Amount
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:TextBox ID="txtamount" runat="server" CssClass="blue1" size="40" ToolTip="Perquisite amount Received"
                                                    Width="88px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtamount"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    ToolTip="Enter Perquisite Amount Received" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtamount"
                                                    Display="Dynamic" ErrorMessage="Enter Correct Amount" MaximumValue="999999" MinimumValue="0"
                                                    Type="Double" ValidationGroup="v"></asp:RangeValidator>
                                                <asp:LinkButton ID="btnadd" runat="server" CssClass="link05" ValidationGroup="v"
                                                    ToolTip="Click to Calculate Perquisite" Text="Calculate" OnClick="btnadd_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123 border-bottom" width="25%">
                                                &nbsp;
                                            </td>
                                            <td class="frm-rght-clr123 border-bottom" width="75%">
                                                &nbsp;<asp:Button ID="btnsubmit" runat="server" CssClass="button" Text="Submit" OnClick="btnsubmit_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                Mandatory Fields (<img alt="" src="../../images/error1.gif" />)
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" height="20">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td class="txt02" width="27%">
                                                Employee Perquisite View
                                            </td>
                                            <td class="txt-red" align="right" width="73%">
                                                <span id="SPAN1" runat="server"></span>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 123px" valign="top">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td width="25%">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grid" runat="server" Width="100%" EmptyDataText="Sorry No Records Found"
                                                            PageSize="50" AllowPaging="true" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                            CellPadding="4" BorderWidth="1px" DataKeyNames="fyear" AutoGenerateColumns="false"
                                                            OnPageIndexChanging="grid_PageIndexChanging" CssClass="gvclass" Border="1px solid #ddd">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Financial Year">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="50%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind("fyear")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Amount">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="50%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l5" runat="server" Text='<%# Bind("amount")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                                            <FooterStyle CssClass="frm-lft-clr123" />
                                                            <RowStyle Height="5px" />
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 18px">
                                            </td>
                                        </tr>
                                    </table>
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
