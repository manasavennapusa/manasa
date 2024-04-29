<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fillApplicants.aspx.cs" Inherits="recruitment_fillApplicants" %>

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
                                <td class="txt01">VACANCY
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
                    <td class="frm-lft-clr123 border-bottom" width="20%">Total Number Of Posts:
                    </td>
                    <td class="frm-lft-clr123 border-bottom" width="30%">
                        <asp:Label ID="lblnoposts" runat="server"></asp:Label>
                    </td>
                    <td class="frm-lft-clr123 border-bottom" width="20%">Number Of Posts Filled:
                    </td>
                    <td class="frm-lft-clr123 border-bottom" width="30%">
                        <asp:Label ID="lblfilledposts" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" height="5"></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="grdvacancy" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" Style="border-right: 1px solid #c9dffb"
                            EmptyDataText="No Data Found">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsno" runat="server" Text=' <%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        <asp:HiddenField ID="hdf" runat="server" Value='<%#Eval("id")%>' />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="5%" />
                                    <ItemStyle CssClass="frm-rght-clr1234" BorderWidth="1px" BorderStyle="solid" BorderColor="#c9dffb"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee/Candidate Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblreq" runat="server" Text='<%#Eval("candidate_name")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="20%" />
                                    <ItemStyle CssClass="frm-rght-clr1234" BorderWidth="1px" BorderStyle="solid" BorderColor="#c9dffb"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Internal/Referra">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldept" runat="server" Text='<%#Eval("referredby")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="20%" />
                                    <ItemStyle CssClass="frm-rght-clr1234" BorderWidth="1px" BorderStyle="solid" BorderColor="#c9dffb"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date of Join">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_doj" runat="server" CssClass="blue1" MaxLength="200" Width="100px"></asp:TextBox>
                                        <asp:Image ID="Image12" runat="server" ImageUrl="~/images/clndr.gif" />
                                        <cc1:CalendarExtender ID="CalendarExtender12" runat="server" PopupButtonID="Image12"
                                            TargetControlID="txt_doj" Enabled="True">
                                        </cc1:CalendarExtender>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                    <ItemStyle CssClass="frm-rght-clr1234" BorderWidth="1px" BorderStyle="solid" BorderColor="#c9dffb"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" />
                                    <ItemStyle CssClass="frm-rght-clr1234" BorderWidth="1px" BorderStyle="solid" BorderColor="#c9dffb"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" height="5"></td>
                </tr>
                <tr>
                    <td colspan="4" width="100%">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td align="right">

                                    <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="button" OnClick="btnsave_Click" />&nbsp;
                                <%--<asp:Button ID="Button2" runat="server" Text="Clear" CssClass="button" />&nbsp;--%>
                                    <asp:Button ID="btnback" runat="server" Text="Back" CssClass="button" OnClick="btnback_Click" />&nbsp;
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
                        <asp:GridView ID="Grdcandidates" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" Style="border-right: 1px solid #c9dffb"
                            EmptyDataText="No Data Found">
                            <Columns>
                                <asp:TemplateField HeaderText="Candidate Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsno" runat="server" Text=' <%# Eval("id") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="5%" />
                                    <ItemStyle CssClass="frm-rght-clr1234" BorderWidth="1px" BorderStyle="solid" BorderColor="#c9dffb"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee/Candidate Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblreq" runat="server" Text='<%#Eval("candidate_name")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="20%" />
                                    <ItemStyle CssClass="frm-rght-clr1234" BorderWidth="1px" BorderStyle="solid" BorderColor="#c9dffb"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Internal/Referra">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldept" runat="server" Text='<%#Eval("referredby")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="20%" />
                                    <ItemStyle CssClass="frm-rght-clr1234" BorderWidth="1px" BorderStyle="solid" BorderColor="#c9dffb"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date of Join">
                                    <ItemTemplate>
                                        <asp:Label ID="doj" runat="server" Text='<%#Eval("dateofjoin","{0:MM/dd/yyyy}")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                    <ItemStyle CssClass="frm-rght-clr1234" BorderWidth="1px" BorderStyle="solid" BorderColor="#c9dffb"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Add Details">
                                    <ItemTemplate>
                                        <a href='../admin/empmaster.aspx?id=<%# Eval("id") %>' class="link05">Add</a>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" />
                                    <ItemStyle CssClass="frm-rght-clr1234" BorderWidth="1px" BorderStyle="solid" BorderColor="#c9dffb"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" height="5"></td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
