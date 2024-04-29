<%@ Page Language="C#" AutoEventWireup="true" CodeFile="documentList.aspx.cs" Inherits="recruitment_documentList" %>

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
                                <td class="txt01">DOCUMENT LIST
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
                    <td class="frm-rght-clr123 border-bottom" width="25%">
                        <asp:DropDownList ID="ddl_document" runat="server" CssClass="blue1" Width="142px" Height="20px" AutoPostBack="true" OnSelectedIndexChanged="ddl_document_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="frm-rght-clr123 border-bottom" width="25%">
                        <asp:TextBox ID="txt_documentname" runat="server" CssClass="blue1" placeholder="Document Name" MaxLength="200" Width="142px"></asp:TextBox>
                    </td>
                    <td class="frm-rght-clr123 border-bottom" width="25%">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button" OnClick="btnSearch_Click" />
                    </td>
                    <td class="frm-rght-clr123 border-bottom " width="25%">
                        <asp:Button ID="btnclear" runat="server" Text="Search Clear" CssClass="button" OnClick="btnclear_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" height="5"></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="grddocument" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" Style="border-right: 1px solid #c9dffb"
                            EmptyDataText="No Data Found" CssClass="gvclass">
                            <Columns>
                                <asp:TemplateField HeaderText=" SELECT">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hfid" runat="server" Value='<%# Eval("id") %>' />
                                        <asp:CheckBox ID="chkselect" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="5%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CODE">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpapercode" runat="server" Text='<%# "DOC"+ Eval("id") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="17%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NAME">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubcode" runat="server" Text='<%# Eval("document_name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="17%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DESCRIPTION">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQUES" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="17%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MANDATORY">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTIME" runat="server" Text='<%# Eval("mandatory").ToString()=="True"?"Yes":"No" %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="17%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/createdocument.aspx?Id={0}"
                                            Text="Edit">
                                            <ControlStyle CssClass="link05" Width="6%" />
                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                            <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                        </asp:HyperLinkField>
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
                                <td align="center">
                                    <asp:Button ID="btnadd" runat="server" Text="Add New" CssClass="button" OnClick="btnaddnew_Click" />&nbsp;
                                <asp:Button ID="btnselectall" runat="server" Text="Select All" CssClass="button" OnClick="btnselectall_Click" />&nbsp;
                                <asp:Button ID="btndeselectall" runat="server" Text="Deselect All" CssClass="button" OnClick="btnDeselectall_Click" />&nbsp;
                                <asp:Button ID="btndelete" runat="server" Text="Delete" CssClass="button" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete selected records ')" />&nbsp;
                                </td>
                            </tr>
                            <%--<tr>
                                <td align="center">
                                    <asp:Button ID="Button5" runat="server" Text="First" CssClass="button" />&nbsp;
                                <asp:Button ID="Button6" runat="server" Text="Previous" CssClass="button" />&nbsp;
                                <asp:Button ID="Button7" runat="server" Text="Next" CssClass="button" />&nbsp;
                                <asp:Button ID="Button8" runat="server" Text="Last" CssClass="button" />&nbsp;
                                </td>
                            </tr>--%>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
