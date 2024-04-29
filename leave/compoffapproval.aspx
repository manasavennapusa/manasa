<%@ Page Language="C#" AutoEventWireup="true" CodeFile="compoffapproval.aspx.cs" Inherits="leave_compoffapproval" %>

<!DOCTYPE html>
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
                                            Comp-Off Approval
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="leave_approval_grid" runat="server" AllowSorting="True"
                                                AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                 DataSourceID="SqlDataSource1" DataKeyNames="id" OnPreRender="leave_approval_grid_PreRender">
                                              
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Employee Code">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Employee Name">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind("empname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Leave Type">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="" Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <%#linkleave(DataBinder.Eval(Container.DataItem, "empcode").ToString(),DataBinder.Eval(Container.DataItem, "leavename").ToString(), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "id")))%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="From Date">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("fromdate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="To Date">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l6" runat="server" Text='<%# Bind("todate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="No of Days">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l7" runat="server" Text='<%# Bind("nod") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-info" Visible='<%#Eval("leavestatus").ToString()=="Pending"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-important" Visible='<%#Eval("leavestatus").ToString()=="Rejected"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-warning" Visible='<%#Eval("leavestatus").ToString()=="Approved,not Updated by HR"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-warning" Visible='<%#Eval("leavestatus").ToString()=="Cancelled"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-success" Visible='<%#Eval("leavestatus").ToString()=="Approved and Updated by HR"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-info" Visible='<%#Eval("leavestatus").ToString()=="Pending for Cancellation"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-info" Visible='<%#Eval("leavestatus").ToString()=="Pending for Modification"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-warning" Visible='<%#Eval("leavestatus").ToString()=="Back to User"?true:false%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>" runat="server" SelectCommand="sp_leave_fetchcompoff_summary" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                                    <asp:SessionParameter Name="empcode" SessionField="empcode" Type="String" DefaultValue="0" />
                                                    <asp:QueryStringParameter Name="hr" QueryStringField="hr" Type="Int32" DefaultValue="0" />
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
        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#leave_approval_grid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>

