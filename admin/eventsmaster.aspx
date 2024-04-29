<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eventsmaster.aspx.cs" Inherits="intranet_eventsmaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<%@ Register Src="~/Controls/Top.ascx" TagName="top" TagPrefix="uc1" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Teamworks :: Intranet Master Entry</title>
    <link href="../css/blue1.css" rel="stylesheet" type="text/css" />
    <script src="../../js/JavaScriptValidations.js"></script>
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
                                    <td valign="bottom">Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" class="blue-brdr-1">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <%--<td width="3%">
                                            <img src="../images/employee-icon.jpg" width="16" height="16" />
                                        </td>--%>
                                        <td class="txt01">Intranet Events Master Form
                                        </td>
                                        <td align="right">
                                            <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" align="Center"></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="frm-lft-clr123" valign="middle">Category <span class="star"></span>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:DropDownList ID="ddlcategory" runat="server" CssClass="blue1">
                                                        </asp:DropDownList>
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlcategory"
                                                            ErrorMessage="Category" Operator="NotEqual" ValidationGroup="v" ValueToCompare="---Select Category---"
                                                            Display="Dynamic"><img src="../img/error1.gif" alt="*" /></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="22%" class="frm-lft-clr123" valign="middle">Heading <span class="star"></span>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txtheading" runat="server" CssClass="blue1" ToolTip="Enter Project Name"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtheading"
                                                            ErrorMessage="Heading" ValidationGroup="v" Display="Dynamic"><img src="../img/error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" valign="top">Event Date <span class="star"></span>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_edate" runat="server" CssClass="blue1"
                                                            onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                                        <asp:RequiredFieldValidator ID="rfvedate" runat="server" ControlToValidate="txt_edate"
                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' SetFocusOnError="True"
                                                            ToolTip="Enter Event Date" ValidationGroup="v" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                            TargetControlID="txt_edate">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" valign="top">Description <span class="star"></span>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txtdescription" runat="server" CssClass="blue1" Height="68px" TextMode="MultiLine"
                                                            ToolTip="Enter Project Name" Width="333px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdescription"
                                                            ErrorMessage="Description" ValidationGroup="v" Display="Dynamic"><img src="../img/error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="1" colspan="2">
                                                        <%--<asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="You must enter a value in following fields"
                                                  ShowMessageBox="True" ShowSummary="False" ValidationGroup="v" />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom">&nbsp;
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Submit" ValidationGroup="v"
                                                            OnClick="btnSave_Click" ToolTip="Click here to save news" />
                                                        <asp:Button ID="btnclear" runat="server" CssClass="button" Text="Reset" OnClick="btnclear_Click"
                                                            ToolTip="Reset" />
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td colspan="2" height="20" valign="bottom">Mandatory Fields (<img src="../img/error1.gif" alt="" />)
                                                    </td>
                                                </tr>--%>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" height="5"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="timesheetgrid" runat="server">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top">
                                <div class="widget-content">
                                    <asp:GridView ID="eventsdetails" runat="server" Width="100%" AutoGenerateColumns="False"
                                        DataKeyNames="id" BorderWidth="0px" CellPadding="4" OnRowDataBound="eventsdetails_RowDataBound"
                                        OnPageIndexChanging="eventsdetails_PageIndexChanging" OnRowDeleting="eventsdetails_RowDeleting"
                                        OnRowCancelingEdit="eventsdetails_RowCancelingEdit" OnRowEditing="eventsdetails_RowEditing"
                                        OnRowUpdating="eventsdetails_RowUpdating" ToolTip="News Details" AllowPaging="True"
                                        CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Category">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "category")%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlcategoryg" runat="server" CssClass="blue1" Width="75px"
                                                        Height="20px" DataSourceID="SqlDataSource1" DataTextField="categoryname" DataValueField="categoryname"
                                                        SelectedValue='<%#Bind("category")%>'>
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct [categoryname] FROM [category]"></asp:SqlDataSource>
                                                </EditItemTemplate>
                                                <%--  <ItemStyle Width="12%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                            <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Heading">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "heading")%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtheadingg" CssClass="blue1" Text='<%#DataBinder.Eval(Container.DataItem, "heading")%>'
                                                        runat="server" Width="75px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <%-- <ItemStyle Width="13%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                            <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Event Date">
   <ItemTemplate><%#DataBinder.Eval(Container.DataItem, "eventdate")%></ItemTemplate>
   <EditItemTemplate></EditItemTemplate>
   </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Description">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "description")%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtdescriptiong" CssClass="blue1" Text='<%#DataBinder.Eval(Container.DataItem, "description")%>'
                                                        runat="server" Width="190px" Height="41px" TextMode="MultiLine"></asp:TextBox>
                                                </EditItemTemplate>
                                                <%-- <ItemStyle Width="29%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                            <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Run Status">
                                                <%-- <ItemStyle Width="12%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                            <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "run_status")%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlrunstatusg" runat="server" Width="75px" CssClass="blue1"
                                                        Height="20px" SelectedValue='<%#Bind("run_status1")%>'>
                                                        <asp:ListItem Value="0">Running</asp:ListItem>
                                                        <asp:ListItem Value="1">Stop</asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Priority">
                                                <%-- <ItemStyle Width="9%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                            <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "priority")%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlpriorityg" runat="server" Width="55px" CssClass="blue1"
                                                        Height="20px" SelectedValue='<%#Bind("priority1")%>'>
                                                        <asp:ListItem Value="0">Low</asp:ListItem>
                                                        <asp:ListItem Value="1">Medium</asp:ListItem>
                                                        <asp:ListItem Value="2">High</asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Updated Date">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "posteddate")%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "posteddate")%>
                                                </EditItemTemplate>
                                                <%--<ItemStyle Width="14%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                            <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to update this entry?')"
                                                        CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" />
                                                    |
                                            <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel"
                                                CssClass="link05" Text="Cancel" ToolTip="Cancel" />
                                                </EditItemTemplate>
                                                <%-- <ItemStyle Width="11%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
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
                        <tr>
                        </tr>
                        <tr>
                            <td align="center"></td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
