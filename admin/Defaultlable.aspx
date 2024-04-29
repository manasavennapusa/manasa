<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Defaultlable.aspx.cs" Inherits="admin_Defaultlable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
    </style>
    <script type="text/javascript" src="../js/JavaScriptValidations.js"></script>

    <link href="../css/table.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
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

                        <%--  <script type="text/javascript">

                            function isChar() {
                                var ch = String.fromCharCode(event.keyCode);
                                var filter = /[a-zA-Z\s]/;
                                if (!filter.test(ch)) {
                                    alert('Please enter only Char')
                                    event.returnValue = false;
                                }
                            }

                        </script>--%>

                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                            <tbody>
                                <tr>
                                    <td valign="top" class="blue-brdr-1" colspan="2">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>

                                                <td class="txt01">
                                                    <asp:Label ID="lblhead" runat="server" Text="Create City"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" valign="top"></td>
                                </tr>
                                <tr id="trlbl" runat="server">
                                    <td valign="top">
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom" width="22%">Lable Name<span class="star"></span>
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom" width="25%">
                                                       <asp:TextBox ID="txt_label" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>


                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10"></td>
                                </tr>
                                <tr id="trbtn" runat="server">
                                    <td colspan="2">
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>

                                                <td align="right" width="80%">
                                                    <asp:Button ID="btncity" runat="server" CssClass="button" OnClick="btncity_Click"
                                                        Text="Save" ValidationGroup="c" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10"></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div class="widget-content">
                                            <asp:GridView ID="grdcity" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100"
                                                EmptyDataText="No Data  Found">
                                                <Columns>
                                                    
                                                    <asp:TemplateField HeaderText="Id">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblid" runat="server" Text='<%#Eval("id")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Lable Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcity" runat="server" Text='<%#Eval("labelname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/admin/Defaultlable.aspx?Id={0}"
                                                        Text="Edit">
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
</body>
</html>
