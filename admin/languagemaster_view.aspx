<%@ Page Language="C#" AutoEventWireup="true" CodeFile="languagemaster_view.aspx.cs" Inherits="admin_languagemaster_view" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
    </style>
<link href="../css/blue1.css" rel="stylesheet" /></head>
<body>
    <form id="cmaster" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                        runat="server">
                        <ProgressTemplate>
                            <div class="divajax">
                                <table width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <img src="../images/loading.gif" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom" align="center" class="txt01" height="23">
                                            Please Wait...
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div>
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td class="blue-brdr-1">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td class="txt01">
                                                Cost Center View
                                            </td>
                                            <td align="right">
                                                <span id="message" class="txt-red" runat="server">&nbsp;</span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="5">
                                </td>
                            </tr>
                            <tr>
                                <td class="head-2">
                                    <asp:GridView ID="grid_language" runat="server" AllowPaging="True" Width="100%"
                                        HorizontalAlign="Left" CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False"
                                        AllowSorting="True" PageSize="100" CssClass="gvclass" BorderWidth="1px" >
                                        <PagerSettings PageButtonCount="100"></PagerSettings>
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                        </HeaderStyle>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Language">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblccg" runat="server" Text='<%# Eval("language") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <a href="langugemaster_edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id") %>"
                                                        target="_self" class="link05">Edit</a>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        </form>
</body>
</html>
