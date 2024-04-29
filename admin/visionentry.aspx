<%@ Page Language="C#" AutoEventWireup="true" CodeFile="visionentry.aspx.cs" Inherits="intranet_visionentry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/blue.css" rel="stylesheet" type="text/css" />
    <link href="../css/blue1.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../css/blue1.css" rel="stylesheet" />--%>

    <style type="text/css">
        .star:before {
            content: " *";
        }
    </style>

    <link href="../js/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../js/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" class="blue-brdr-1">
                                    <tr>
                                        <%--<td width="3%">
                                            <img src="../images/employee-icon.jpg" width="16" height="16" />
                                        </td>--%>
                                        <td class="txt01">Vision/Mission Posting Form
                                        </td>
                                    </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="5" valign="top">
                        <span id="message" runat="server" class="txt02" enableviewstate="false"></span>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="25%" class="frm-lft-clr123">Type <span class="star"></span>
                                </td>
                                <td width="75%" class="frm-rght-clr123">
                                    <asp:DropDownList ID="ddltype" runat="server" CssClass="blue1" Width="" Height="">
                                        <asp:ListItem>---Select Type---</asp:ListItem>
                                        <asp:ListItem>Mission</asp:ListItem>
                                        <asp:ListItem>Vision</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddltype"
                                        ErrorMessage="Select Type" InitialValue="---Select Type---" ValidationGroup="v"><img src="../images\error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td width="25%" class="frm-lft-clr123">Heading <span class="star"></span>
                                </td>
                                <td width="75%" class="frm-rght-clr123">&nbsp;<asp:TextBox ID="txtsubject" runat="server" CssClass="blue1" Width="235px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsubject" ErrorMessage="Subject"
                                    ValidationGroup="v"><img src="../img/error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td width="25%" class="frm-lft-clr123 border-bottom" valign="top">Description <span class="star"></span>
                                </td>
                                <td width="75%" class="frm-rght-clr123 border-bottom">&nbsp;<asp:TextBox ID="txtdescription" runat="server" CssClass="blue1" Width="238px"
                                    Height="59px" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdescription"
                                        ErrorMessage="Description" ValidationGroup="v"><img src="../img/error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td valign="top" height="10">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
                            HeaderText="Enter a value for following fields" Height="1px" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="v" Width="280px" />
                        <%--<span style="color: #ff0033">All fields are Mandatory&nbsp;</span>--%>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <asp:Button ID="btnsubmit" runat="server" CssClass="button" Text="Submit" OnClick="btnsubmit_Click" Height="33px"
                            ValidationGroup="v" />
                        <asp:Button ID="btnreset" runat="server" CssClass="button" Text="Reset" OnClick="btnreset_Click" Height="33px" />

                    </td>
                </tr>
                <tr>
                    <td valign="top">&nbsp;
                    </td>
                </tr>
            </table>

            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top">

                        <div class="widget-content">

                            <asp:GridView ID="griddetails" runat="server" Width="100%" AutoGenerateColumns="False"
                                DataKeyNames="id"  OnRowDataBound="griddetails_RowDataBound"
                                OnPageIndexChanging="griddetails_PageIndexChanging" OnRowDeleting="griddetails_RowDeleting"
                                OnRowCancelingEdit="griddetails_RowCancelingEdit" OnRowEditing="griddetails_RowEditing"
                                OnRowUpdating="griddetails_RowUpdating" ToolTip="Catalog Details" AllowPaging="True" 
                                CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                <Columns>
                                    <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "mission_vision")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddltype" runat="server" CssClass="blue1" Height="20px" Width="117px">
                                                <asp:ListItem>Mission</asp:ListItem>
                                                <asp:ListItem>Vision</asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <%-- <ItemStyle Width="8%" />--%>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Heading">
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "heading")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtgsubject" CssClass="blue1" Text='<%#DataBinder.Eval(Container.DataItem, "heading")%>'
                                                runat="server" Width="100px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Subjet can not be blank" ControlToValidate="txtgsubject" ValidationGroup="othrsrcincgird"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <%--<ItemStyle Width="24%" />--%>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Description">
                                        <%--<ItemStyle Width="32%" />--%>
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "description")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtgdescription" CssClass="blue1" Text='<%#DataBinder.Eval(Container.DataItem, "description")%>'
                                                TextMode="MultiLine" runat="server" Width="220px" Height="47px"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lnkbtnupdate" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to update this entry?')"
                                                CommandName="Update" CssClass="link04" Text="Update" ToolTip="Update" />
                                            |
                                    <asp:LinkButton ID="lnkbtncancel" runat="server" CausesValidation="false" CommandName="Cancel"
                                        CssClass="link04" Text="Cancel" ToolTip="Cancel" />
                                        </EditItemTemplate>
                                        <%--<ItemStyle Width="20%" VerticalAlign="Top" />--%>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                CssClass="link04" Text="Edit" ToolTip="Edit" />
                                            |
                                    <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to delete this entry?')"
                                        CommandName="Delete" CssClass="link04" Text="delete" ToolTip="Delete" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <%--<AlternatingRowStyle CssClass="light-gray" />--%>
                                <%--<HeaderStyle CssClass="nav-head-1" HorizontalAlign="Left" />--%>
                                <EmptyDataRowStyle  HorizontalAlign="Left" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
