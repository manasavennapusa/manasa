<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewodstatus.aspx.cs" Inherits="leave_viewodstatus" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
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
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>
                                            View OD Status
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <asp:GridView ID="leave_approval_grid" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
                                            DataSourceID="SqlDataSource2" OnPreRender="leave_approval_grid_PreRender1"  CssClass="table table-condensed table-striped table-hover table-bordered pull-left">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Leave Type">
                                                    <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                                                    <ItemTemplate>
                                                        <%#linkleave(DataBinder.Eval(Container.DataItem, "empcode").ToString(), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "id")), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Approval_status")))%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="From Date">
                                                    <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="l5" runat="server" Text='<%# Bind("fromdate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="To Date">
                                                    <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="l6" runat="server" Text='<%# Bind("todate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="No of Days">
                                                    <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="l7" runat="server" Text='<%# Bind("nod") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                        </asp:GridView>
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                            DeleteCommand="DELETE FROM [tbl_leave_createleave] WHERE [leaveid] = @leaveid"
                                            InsertCommand="INSERT INTO [tbl_leave_createleave] ([leavetype]) VALUES (@leavetype)"
                                            ProviderName="System.Data.SqlClient" SelectCommand="sp_leave_fetchodsummary_user"
                                            SelectCommandType="StoredProcedure" UpdateCommand="UPDATE [tbl_leave_createleave] SET [leavetype] = @leavetype WHERE [leaveid] = @leaveid">
                                            <DeleteParameters>
                                                <asp:Parameter Name="leaveid" Type="Int32" />
                                            </DeleteParameters>
                                            <UpdateParameters>
                                                <asp:Parameter Name="leavetype" Type="String" />
                                                <asp:Parameter Name="leaveid" Type="Int32" />
                                            </UpdateParameters>
                                            <InsertParameters>
                                                <asp:Parameter Name="leavetype" Type="String" />
                                            </InsertParameters>
                                            <SelectParameters>
                                                <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                                <asp:SessionParameter DefaultValue="0" Name="empcode" SessionField="empcode" Type="String" />
                                                <asp:QueryStringParameter DefaultValue="0" Name="leavestatus" QueryStringField="leavestatus"
                                                    Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
       <%-- <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#leave_approval_grid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>--%>
    </form>
</body>
</html>
