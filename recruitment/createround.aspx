<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createround.aspx.cs"
    Inherits="createround" %>

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
    <script language="javascript" type="text/javascript" src="js/JavaScriptValidations.js"></script>

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
                                <td class="txt01">
                                    <asp:Label ID="lblheader" runat="server" Text="CREATE ROUND"></asp:Label>
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
                <%--<tr>
                    <td class="frm-lft-clr123" width="30%">Round Id
                    </td>
                    <td class="frm-rght-clr123" width="25%">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="blue1" MaxLength="200" Width="142px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="5"></td>
                </tr>--%>
                <tr>
                    <td class="frm-lft-clr123" width="30%">Round Name
                    </td>
                    <td class="frm-rght-clr123" width="25%">
                        <asp:TextBox ID="txt_roundname" runat="server" CssClass="blue1" MaxLength="200" Width="142px" onkeypress="return isCharOrSpace()"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_roundname"
                            ValidationGroup="r" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only Alphabets and (space)"
                            ErrorMessage='<img src=" images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_roundname"
                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Round Name"
                            ValidationGroup="r" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <%--<tr>
                    <td colspan="2" height="5"></td>
                </tr>--%>
                <tr>
                    <td class="frm-lft-clr123" width="30%">Category
                    </td>
                    <td class="frm-rght-clr123" width="25%">
                        <asp:DropDownList ID="ddl_category" runat="server" CssClass="blue1" Width="142px" Height="20px">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem>Written</asp:ListItem>
                            <asp:ListItem>Online</asp:ListItem>
                            <asp:ListItem>Interview</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <%--<tr>
                    <td colspan="2" height="5"></td>
                </tr>--%>
                <tr>
                    <td class="frm-lft-clr123 border-bottom" width="30%">Category Type
                    </td>
                    <td class="frm-rght-clr123 border-bottom" width="25%">
                        <asp:DropDownList ID="ddl_cat_type" runat="server" CssClass="blue1" Width="142px"
                            Height="20px">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem>Technical</asp:ListItem>
                            <asp:ListItem>Non Technical</asp:ListItem>
                            <asp:ListItem>General</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="5"></td>
                </tr>
                <tr>
                    <td width="30%">
                        <%--&nbsp;&nbsp;&nbsp;&nbsp; Mandatory Fields (<img alt="" src="../images/error1.gif" />)--%>
                    </td>
                    <td align="right" width="70%">
                        <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="button" ValidationGroup="r" OnClick="btnadd_Click" />
                        &nbsp;
                    <asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="button" OnClick="btnclear_Click" /> &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="5"></td>
                </tr>
                 <tr>
                    <td colspan="4">
                        <asp:GridView ID="grdrounds" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" Style="border-right: 1px solid #c9dffb"
                            EmptyDataText="No Data Found" CssClass="gvclass">
                            <Columns>
                                <asp:TemplateField HeaderText=" Select">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hfid" runat="server" Value='<%# Eval("id") %>' />
                                        <asp:CheckBox ID="chkselect" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblname" runat="server" Text='<%#  Eval("round_name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="30%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Category">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategory" runat="server" Text='<%#  Eval("category") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="30%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Category Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategoryType" runat="server" Text='<%#  Eval("category_type") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="30%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/createround.aspx?Id={0}"
                                    Text="Edit">
                                    <ControlStyle CssClass="link05" Width="6%" />
                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:HyperLinkField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
