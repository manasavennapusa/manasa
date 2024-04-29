<%@ Page Language="C#" AutoEventWireup="true" CodeFile="subjectList.aspx.cs" Inherits="recruitment_subjectList" %>

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
                                <td class="txt01">SUBJECT LIST
                                </td>
                                <td align="right">
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" height="5"></td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123 border-bottom" width="15%">Subject Name
                    </td>
                    <td class="frm-rght-clr123 border-bottom" width="15%">
                        <asp:TextBox ID="txtSubjectname" runat="server" CssClass="blue1" MaxLength="50" Width="142px"></asp:TextBox>
                    </td>
                    <td class="frm-lft-clr123 border-bottom" width="20%">Sub-Subject Name
                    </td>
                    <td class="frm-rght-clr123 border-bottom" width="15%">
                        <asp:TextBox ID="txtsub_Subjectname" runat="server" CssClass="blue1" MaxLength="50" Width="142px"></asp:TextBox>
                    </td>
                    <td class="frm-rght-clr123 border-bottom" width="12%">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button" OnClick="btnSearch_Click" />
                    </td>
                    <td class="frm-rght-clr123 border-bottom " width="18%">
                        <asp:Button ID="btnclear" runat="server" Text="Search Clear" CssClass="button" OnClick="btnclear_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" height="5"></td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:GridView ID="grdsubject" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" Style="border-right: 1px solid #c9dffb"
                            EmptyDataText="No Data Found" CssClass="gvclass">
                            <Columns>
                                <asp:TemplateField HeaderText=" Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkselect" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubcode" runat="server" Text='<%# Eval("subject_code") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Subject Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubname" runat="server" Text='<%# Eval("subject_name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="25%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Sub Subject Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lbls_subname" runat="server" Text='<%# Eval("sub_subject_name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="25%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/createsubject.aspx?Id={0}"
                                    Text="Edit">
                                    <ControlStyle CssClass="link05" Width="6%" />
                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:HyperLinkField>
                                <asp:HyperLinkField HeaderText="Questions" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/questionList.aspx?Id={0}"
                                    Text="Questions">
                                    <ControlStyle CssClass="link05" Width="6%" />
                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:HyperLinkField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="6" height="5"></td>
                </tr>
                <tr>
                    <td colspan="6" width="100%">
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
                                    <asp:Button ID="btnadd" runat="server" Text="Add New" CssClass="button" OnClick="btnaddnew_Click" />&nbsp;
                                <asp:Button ID="btnselectall" runat="server" Text="Select All" CssClass="button" OnClick="btnselectall_Click" />&nbsp;
                                <asp:Button ID="btndeselectall" runat="server" Text="Deselect All" CssClass="button" OnClick="btnDeselectall_Click" />&nbsp;
                                <asp:Button ID="btndelete" runat="server" Text="Delete" CssClass="button" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete selected records ')" />&nbsp;
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
