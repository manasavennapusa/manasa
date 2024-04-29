<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createscheme.aspx.cs" Inherits="createscheme" %>

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
                                <td class="txt01">
                                    <asp:Label ID="lblheader" runat="server" Text="ADD SECHME"></asp:Label>
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
                    <td class="frm-lft-clr123" width="40%">Scheme Name
                    </td>
                    <td class="frm-rght-clr123" width="60%">
                        <asp:TextBox ID="txt_schemename" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_schemename"
                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Scheme Name"
                            ValidationGroup="r" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <%--<tr>
                    <td colspan="2" height="5"></td>
                </tr>--%>
                <tr>
                    <td colspan="2" class="border-bottom">

                        <asp:GridView ID="grdschemelist" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" Style="border-right: 1px solid #c9dffb"
                            EmptyDataText="No Data Found" CssClass="gvclass">
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddl_roundtype" runat="server" CssClass="blue1" Width="100px"
                                        Height="20px">
                                    </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Round Type">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                    <EditItemTemplate>

                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Priority">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Time (MM)">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">                            
                            <tr>
                                <td class="frm-rght-clr123">
                                    <asp:CheckBox ID="chkselect" runat="server" />
                                </td>
                                <td class="frm-rght-clr123">
                                    
                                </td>
                                <td class="frm-rght-clr123">
                                    <asp:DropDownList ID="ddl_Prority" runat="server" CssClass="blue1" Width="50px" Height="20px">
                                    </asp:DropDownList>
                                </td>
                                <td class="frm-rght-clr123">
                                    <asp:TextBox ID="txt_time" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="5"></td>
                </tr>
                <tr>
                    <td align="center" width="70%" colspan="2">
                        <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="button" ValidationGroup="r" OnClick="btnadd_Click" />
                        &nbsp;
                    <asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="button" OnClick="btnclear_Click" />
                        &nbsp;
                    <asp:Button ID="btnaddrow" runat="server" Text="Add Row" CssClass="button" />
                        &nbsp;
                    <asp:Button ID="btndeleterow" runat="server" Text="Delete Row" CssClass="button" />
                        &nbsp;
                    <asp:Button ID="btnBack" runat="server" Text="Back To List" CssClass="button" />
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
