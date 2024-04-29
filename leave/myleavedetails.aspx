<%@ Page Language="C#" AutoEventWireup="true" CodeFile="myleavedetails.aspx.cs" Inherits="leave_myleavedetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>
                                    <asp:Label runat="server" ID="headername"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="grid_leave" runat="server" AutoGenerateColumns="False"
                                        CssClass="table table-condensed table-striped table-hover table-bordered pull-left" OnPreRender="grid_leave_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Leave Type" HeaderStyle-Width="25%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l5" runat="server" Text='<%# Bind("leavetype") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date Range" HeaderStyle-Width="25%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l7" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No of Days" HeaderStyle-Width="25%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l7" runat="server" Text='<%# Bind("day") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle Height="5px" />
                                    </asp:GridView>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
    </form>
</body>
</html>

