<%@ Page Language="C#" AutoEventWireup="true" CodeFile="myquerystatus.aspx.cs" Inherits="Query_myquerystatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <link href="../css/main.css" rel="stylesheet">
    <link href="../css/blue1.css" rel="stylesheet" />
    <style type="text/css">
        .star {
            content: " *";
            margin-left: 5px;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="SM1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hdnId" runat="server" />

        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <asp:Label ID="lblheadingcreate" runat="server"><h2>View Query Status</h2></asp:Label>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    My Query Status
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="suggestionsgrid" runat="server" Width="100%" AutoGenerateColumns="False"
                                        DataKeyNames="id" BorderWidth="0px" CellPadding="4" OnPageIndexChanging="suggestions_PageIndexChanging" EmptyDataText="No records found!"
                                        ToolTip="Read Feedback" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Query Type">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "queryTypeName")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description">
                                                <ItemTemplate>
                                                    <a href="ViewqueryDetail.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>&page=<%# Eval("Other")%>"
                                                        target="_self" class="link05">
                                                        <%#DataBinder.Eval(Container.DataItem, "description")%>...</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Ticket Type">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "tickettype")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Priority">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "priority")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemStyle Width="12%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "status")%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlapprovalstatus" runat="server" Width="95px" SelectedValue='<%#Bind("status1")%>' CssClass="blue1" Height="20px">
                                                        <asp:ListItem Value="0">Open</asp:ListItem>
                                                        <asp:ListItem Value="1">Closed</asp:ListItem>
                                                        <asp:ListItem Value="2">Under Review</asp:ListItem>
                                                        <asp:ListItem Value="3">Scrapped</asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Posted Date">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "posteddate")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Closed Date">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "approvedDate")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Approver Code">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "approverCode")%><b>-</b> <%#DataBinder.Eval(Container.DataItem, "emp_fname")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Comment">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "comment")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <a href="raiseticket.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>"
                                                        target="_self">Edit</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
