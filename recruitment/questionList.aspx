<%@ Page Language="C#" AutoEventWireup="true" CodeFile="questionList.aspx.cs" Inherits="recruitment_questionList" %>

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
                                <td class="txt01">QUESTION LIST
                                </td>
                                <td align="right">
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="border-bottom">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td class="frm-lft-clr123">Question Code:
                                </td>
                                <td class="frm-rght-clr123">
                                    <asp:TextBox ID="txt_search" runat="server" CssClass="blue1" Width="150px"></asp:TextBox>
                                </td>
                                <td class="frm-lft-clr123">Sub-Subject:
                                </td>
                                <td class="frm-rght-clr123">
                                    <asp:DropDownList ID="ddl_subsubject" runat="server" CssClass="blue1" Width="100px">
                                    </asp:DropDownList>
                                </td>
                                <td class="frm-lft-clr123">Category:
                                </td>
                                <td class="frm-rght-clr123">
                                    <asp:DropDownList ID="ddl_category" runat="server" CssClass="blue1" Width="100px">
                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                        <asp:ListItem>Written</asp:ListItem>
                                        <asp:ListItem>Online</asp:ListItem>
                                        <asp:ListItem>Interview</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button" OnClick="btnSearch_Click" />&nbsp;
                            <asp:Button ID="btnclear" runat="server" Text="Clear Search" CssClass="button" OnClick="btnclear_Click" />&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" height="5px"></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="grdQuestion" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" Style="border-right: 1px solid #c9dffb"
                            EmptyDataText="No Data Found" CssClass="gvclass">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hfid" runat="server" Value='<%# Eval("id") %>' />
                                        <asp:CheckBox ID="chkselect" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="5%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Question Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQues_code" runat="server" Text='<%# Eval("question_code") %>'>></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sub-Subject Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSub_s_name" runat="server" Text='<%# Eval("sub_subject_name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="12%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcategoryname" runat="server" Text='<%# Eval("category_name") %>'>></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Question Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblques_desc" runat="server" Text='<%# Eval("question_desc") %>'>></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="20%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option A">
                                    <ItemTemplate>
                                        <asp:Label ID="lblA" runat="server" Text='<%# Eval("option_a_desc") %>'>></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="8%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option B">
                                    <ItemTemplate>
                                        <asp:Label ID="lblB" runat="server" Text='<%# Eval("option_b_desc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="8%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option C">
                                    <ItemTemplate>
                                        <asp:Label ID="lblC" runat="server" Text='<%# Eval("option_c_desc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="8%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option D">
                                    <ItemTemplate>
                                        <asp:Label ID="lblD" runat="server" Text='<%# Eval("option_d_desc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="8%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option E">
                                    <ItemTemplate>
                                        <asp:Label ID="lblE" runat="server" Text='<%# Eval("option_e_desc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="8%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/createquestion.aspx?Id={0}"
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
                    <td colspan="4" height="5"></td>
                </tr>
                <tr>
                    <td colspan="4" width="100%" class="frm-rght-clr123 ">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <%--<tr>
                                <td align="center">
                                    <asp:Button ID="Button5" runat="server" Text="First" CssClass="button" />&nbsp;
                                <asp:Button ID="Button6" runat="server" Text="Previous" CssClass="button" />&nbsp;
                                <asp:Button ID="Button7" runat="server" Text="Next" CssClass="button" />&nbsp;
                                <asp:Button ID="Button8" runat="server" Text="Last" CssClass="button" />&nbsp;
                                <asp:TextBox ID="txt_go" runat="server" Width="40"></asp:TextBox>&nbsp;
                                <asp:Button ID="Button1" runat="server" Text="Go" CssClass="button" />&nbsp;
                                <asp:Label ID="lblpageno" runat="server"></asp:Label>
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnaddnew" runat="server" Text="Add New" CssClass="button" OnClick="btnaddnew_Click" />&nbsp;
                                <asp:Button ID="btnselectall" runat="server" Text="Select All" CssClass="button" OnClick="btnselectall_Click" />&nbsp;
                                <asp:Button ID="btnDeselectall" runat="server" Text="Deselect All" CssClass="button" OnClick="btnDeselectall_Click" />&nbsp;
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete selected records ')" />&nbsp;
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
