<%@ Page Language="C#" AutoEventWireup="true" CodeFile="financialentry.aspx.cs" Inherits="intranet_financialentry" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/blue1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .gvclass th {
            text-align: left;
            background-color: #F9F9F9;
            border: 1px solid #ddd;
        }
    </style>
    <style type="text/css">
        .star:before {
            content: " *";
        }
    </style>

    <link href="../js/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../js/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/blue1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                        DisplayAfter="1">
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
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="top" class="blue-brdr-1">
                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <%--<td width="3%">
                                                            <img src="../images/employee-icon.jpg" width="16" height="16" />
                                                        </td>--%>
                                                        <td class="txt01">Financial Posting Form
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
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="25%" class="frm-lft-clr123">Heading <span class="star"></span>
                                                        </td>
                                                        <td width="75%" class="frm-rght-clr123">
                                                            <asp:TextBox ID="txtsubject" runat="server" CssClass="blue1" Width="235px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsubject" ErrorMessage="Subject"
                                                                ValidationGroup="v"><img src="..\images\error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td width="25%" class="frm-lft-clr123" valign="top">Description <span class="star"></span>
                                                        </td>
                                                        <td width="75%" class="frm-rght-clr123">
                                                            <asp:TextBox ID="txtdescription" runat="server" CssClass="blue1" Width="238px" Height="59px"
                                                                TextMode="MultiLine"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdescription"
                                                                ErrorMessage="Description" ValidationGroup="v"><img src="..\images\error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td width="25%" class="frm-lft-clr123 border-bottom" valign="top">&nbsp;
                                                        </td>
                                                        <td width="75%" class="frm-rght-clr123 border-bottom">
                                                            <asp:Button ID="btnsubmit" runat="server" CssClass="button" Text="Submit" OnClick="btnsubmit_Click"
                                                                ValidationGroup="v" />&nbsp;
                                                        <asp:Button ID="btnreset" runat="server" CssClass="button" Text="Reset" OnClick="btnreset_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <%--<td colspan="2" height="20" valign="bottom">Mandatory Fields (<img src="../img/error1.gif" alt="" />)
                                            </td>--%>
                                        </tr>
                                        <tr>
                                            <td valign="top" height="5"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top">
                                    <div class="widget-content">
                                        <asp:GridView ID="griddetails" runat="server" Width="100%" AutoGenerateColumns="False"
                                            DataKeyNames="id" BorderWidth="0px" CellPadding="4" OnRowDataBound="griddetails_RowDataBound"
                                            OnPageIndexChanging="griddetails_PageIndexChanging" OnRowDeleting="griddetails_RowDeleting"
                                            OnRowCancelingEdit="griddetails_RowCancelingEdit" OnRowEditing="griddetails_RowEditing"
                                            OnRowUpdating="griddetails_RowUpdating" ToolTip="Catalog Details" AllowPaging="True"
                                            CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Heading">
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "heading")%>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtgsubject" CssClass="blue1" Text='<%#DataBinder.Eval(Container.DataItem, "heading")%>'
                                                            runat="server" Width="100px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <%-- <ItemStyle Width="25%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                    <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Description">
                                                   <%-- <ItemStyle Width="62%" CssClass="frm-rght-clr1234" />
                                                    <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "description")%>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtgdescription" CssClass="blue1" Text='<%#DataBinder.Eval(Container.DataItem, "description")%>'
                                                            TextMode="MultiLine" runat="server" Width="320px" Height="47px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField>
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnupdate" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to update this entry?')"
                                                            CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" />
                                                        |
                                                <asp:LinkButton ID="lnkbtncancel" runat="server" CausesValidation="false" CommandName="Cancel"
                                                    CssClass="link05" Text="Cancel" ToolTip="Cancel" />
                                                    </EditItemTemplate>
                                                  <%--  <ItemStyle Width="13%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                    <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                            CssClass="link05" Text="Edit" ToolTip="Edit" />
                                                        |
                                                <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to delete this entry?')"
                                                    CommandName="Delete" CssClass="link05" Text="Delete" ToolTip="Delete" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <%--<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123"></HeaderStyle>--%>
                                            <FooterStyle CssClass="frm-lft-clr123" />
                                            <EmptyDataRowStyle CssClass="head" HorizontalAlign="Left" />
                                            <PagerStyle CssClass="frm-lft-clr123" />
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
</body>
</html>
