<%@ Page Language="C#" AutoEventWireup="true" CodeFile="costcenterview.aspx.cs" Inherits="admin_costcenterview" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
    </style>

    <script type="text/javascript" src="../js/tabber.js"></script>

    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
    <link href="../js/A.bootstrap.min.css.pagespeed.cf.oYSzO0tvx-.css" rel="stylesheet" />
    <link href="../js/main.css" rel="stylesheet" />
    <link href="../css/blue1.css" rel="stylesheet" />

</head>
<body>
    <div class="header">
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
                                            <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
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
                                                <td class="txt01">Cost Center View
                                                </td>
                                                <td align="right">
                                                    <span id="message" class="txt-red" runat="server">&nbsp;</span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5"></td>
                                </tr>
                                <tr>
                                    <td class="">
                                        <div class="widget-content">
                                            <asp:GridView ID="Grid_costcenter" runat="server" AllowPaging="True" Width="100%"
                                                HorizontalAlign="Left" CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False"
                                                AllowSorting="True" PageSize="100" BorderWidth="0px"
                                                CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                <PagerSettings PageButtonCount="100"></PagerSettings>
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass=""></HeaderStyle>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Cost Center Group">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblccg" runat="server" Text='<%# Eval("cost_center_group_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle CssClass="" />
                                                        <HeaderStyle CssClass="" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cost Center Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblccg" runat="server" Text='<%# Eval("cost_center_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle CssClass="" />
                                                        <HeaderStyle CssClass="" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cost Center Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblccg" runat="server" Text='<%# Eval("cost_center_code") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle CssClass="" />
                                                        <HeaderStyle CssClass="" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <a href="costcenteredit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id") %>"
                                                                target="_self" class="">Edit</a>
                                                        </ItemTemplate>
                                                        <ItemStyle CssClass="" />
                                                        <HeaderStyle CssClass="" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </form>
    </div>
</body>
</html>
