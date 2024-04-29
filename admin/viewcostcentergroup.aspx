<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewcostcentergroup.aspx.cs"
    Inherits="admin_viewcostcentergroup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Admin Panel</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
    </style>
    
  <link href="../css/table.css" rel="stylesheet" />

    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>



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
                            <tbody>
                                <tr>
                                    <td class="blue-brdr-1">
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td class="txt01">
                                                    Cost Center Group View
                                                </td>
                                                <td align="right">
                                                    <span id="message1" class="txt-red" runat="server">&nbsp;</span>
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
                                    <td class="">
                                        <div class="widget-content">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                                            CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100"  CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Cost Center Group Name" HeaderStyle-CssClass="frm-lft-clr123 ">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblentity" runat="server" Text='<%# Eval("cost_center_group_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    </asp:TemplateField>
                                                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/admin/editcostcentergroup.aspx?Id={0}">
                                                    <ControlStyle CssClass="link05" Width="6%" />
                                                    
                                                </asp:HyperLinkField>
                                            </Columns>
                                        </asp:GridView>
                                            </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        </form>
    </div>
</body>
</html>
