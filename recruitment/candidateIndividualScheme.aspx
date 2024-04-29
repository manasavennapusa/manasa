<%@ Page Language="C#" AutoEventWireup="true" CodeFile="candidateIndividualScheme.aspx.cs"
    Inherits="recruitment_candidateIndividualScheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
        @import "../css/ajax__tab_xp2.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td valign="top" class="blue-brdr-1" colspan="4">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="3%">
                                    <img src="../images/employee-icon.jpg" width="16" height="16" />
                                </td>
                                <td class="txt01">CANDIDATE SCHEME MAP
                                </td>
                                <td align="right">
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4"></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="grdIndivialscheme" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" Style="border-right: 1px solid #c9dffb"
                            EmptyDataText="No Data Found" CssClass="gvclass">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkselect" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="8%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Candidata Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_code" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="12%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Candidata Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_name" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="12%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <asp:Label ID="lblemail" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Phone No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Scheme">
                                    <ItemTemplate>
                                        <asp:Label ID="lblA" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Call Date/Time">
                                    <ItemTemplate>
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="frm-rght-clr1234">
                                                    <asp:TextBox ID="txt_date" runat="server"  Width="80px"></asp:TextBox>
                                                    <asp:Image ID="Image12" runat="server" ImageUrl="~/images/clndr.gif" />
                                                    <cc1:CalendarExtender ID="CalendarExtender12" runat="server" PopupButtonID="Image12"
                                                        TargetControlID="txt_date" Enabled="True">
                                                    </cc1:CalendarExtender>
                                                </td>
                                                <td class="frm-rght-clr1234">/<asp:TextBox ID="txt_time" runat="server"  Width="40px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="20%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Attended">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkselect" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="5%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" height="5"></td>
                </tr>

                <tr>
                    <td colspan="4" width="100%" class="frm-rght-clr123 ">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="Button5" runat="server" Text="First" CssClass="button" />&nbsp;
                                <asp:Button ID="Button6" runat="server" Text="Previous" CssClass="button" />&nbsp;
                                <asp:Button ID="Button7" runat="server" Text="Next" CssClass="button" />&nbsp;
                                <asp:Button ID="Button8" runat="server" Text="Last" CssClass="button" />&nbsp;
                                <asp:TextBox ID="txt_go" runat="server" Width="40"></asp:TextBox>&nbsp;
                                <asp:Button ID="Button1" runat="server" Text="Go" CssClass="button" />&nbsp;
                                <asp:Label ID="lblpageno" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="Button2" runat="server" Text="Select All" CssClass="button" />&nbsp;
                                <asp:Button ID="Button3" runat="server" Text="Deselect All" CssClass="button" />&nbsp;
                                <asp:Button ID="Button10" runat="server" Text="Add New" CssClass="button" />&nbsp;
                                <asp:Button ID="Button4" runat="server" Text="Delete" CssClass="button" />&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
