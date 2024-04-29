<%@ Page Language="C#" AutoEventWireup="true" CodeFile="schemeList.aspx.cs" Inherits="recruitment_schemeList" %>

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
                                <td class="txt01">SECHMES LIST
                                </td>
                                <td align="right">
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="5"></td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123 border-bottom" width="20%">Designation
                    </td>
                    <td class="frm-rght-clr123 border-bottom" width="25%">
                        <asp:DropDownList ID="ddl_designation" runat="server" CssClass="blue1" Width="142px"
                            Height="20px">
                        </asp:DropDownList>
                    </td>
                    <td align="right" class="frm-rght-clr123 border-bottom" width="55%">
                        <asp:Button ID="btnGo" runat="server" Text="Go" CssClass="button" />
                        &nbsp
                    </td>
                </tr>
                <tr>
                    <td colspan="3" height="5"></td>
                </tr>


                <tr>
                    <td colspan="3">
                        <asp:GridView ID="grdschemelist" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" Style="border-right: 1px solid #c9dffb"
                            EmptyDataText="No Data Found" CssClass="gvclass">
                            <Columns>
                                <asp:TemplateField HeaderText=" SECHME DETAILS">
                                    <ItemTemplate>
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="frm-rght-clr123" width="60%">
                                                    <asp:CheckBox ID="chkselect" Text="Scheme:" runat="server" />
                                                </td>
                                                <td colspan="2" class="frm-rght-clr123" width="40%">
                                                    <asp:Button ID="btnedit" runat="server" Text="Edit" CssClass="button" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" width="60%">Round Type
                                                </td>
                                                <td class="frm-lft-clr123" width="20%">Priority
                                                </td>
                                                <td class="frm-lft-clr123" width="20%">Time (MM)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblroundtype" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPrority" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbltime" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="100%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" height="5"></td>
                </tr>
                <tr>

                    <td align="center" width="70%" colspan="3">
                        <asp:Button ID="btnselectAll" runat="server" Text="Select All" CssClass="button" />
                        &nbsp;
                    <asp:Button ID="btndeselectAll" runat="server" Text="Deselect All" CssClass="button" />
                        &nbsp;
                    <asp:Button ID="Button2" runat="server" Text="Add New" CssClass="button" />
                        &nbsp;
                    <asp:Button ID="Button3" runat="server" Text="Delete" CssClass="button" />
                    </td>

                </tr>
                <tr>
                    <td colspan="2" height="5"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
