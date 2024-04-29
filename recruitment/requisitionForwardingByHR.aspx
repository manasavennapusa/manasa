<%@ Page Language="C#" AutoEventWireup="true" CodeFile="requisitionForwardingByHR.aspx.cs" Inherits="recruitment_requisitionForwardingByHR" %>

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
                                <td class="txt01">REQUISITION FORWARDING BY HR
                                </td>
                                <td align="right">
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>


                <tr>
                    <td colspan="4" height="5"></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="grdRRF" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" Style="border-right: 1px solid #c9dffb"
                            EmptyDataText="No Data Found">
                            <Columns>
                                <asp:TemplateField HeaderText=" S.No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSno" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText=" Requsted By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRequstedBy" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="20%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Designation">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="20%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Department">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="20%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Vies">
                                    <ItemTemplate>
                                        <asp:Label ID="lblView" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Send">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" />
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
                    <td colspan="4" width="100%" >
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>



                                <td>
                                    <asp:Button ID="Button5" runat="server" Text="First" CssClass="button" />&nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="Button6" runat="server" Text="Previous" CssClass="button" />&nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="Button7" runat="server" Text="Next" CssClass="button" />&nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="Button8" runat="server" Text="Last" CssClass="button" />&nbsp;
                                </td>
                                <td>&nbsp;
                                <asp:Button ID="Button2" runat="server" Text="Send" CssClass="button" />&nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="Button10" runat="server" Text="Back" CssClass="button" />&nbsp;
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
