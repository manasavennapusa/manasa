<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HolidayWorkStatusApprover.aspx.cs" Inherits="leave_HolidayWorkStatusApprover" %>

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
                                            <asp:Label ID="Label1" runat="server" Text="Holiday Work Status"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="leave_approval_grid" runat="server" AutoGenerateColumns="False"  DataKeyNames="id" EmptyDataText="no records found!!."
                                                CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" OnPreRender="leave_approval_grid_PreRender">
                                                <Columns>
                                                     <asp:TemplateField HeaderText="EmpCode">
                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="" Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "empcode")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="EmpName">
                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            <ItemStyle CssClass="" Width="20%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="l4" runat="server" Text='<%# Bind("empname") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Date">
                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            <ItemStyle CssClass="" Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="l5" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Day">
                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            <ItemStyle CssClass="" Width="6%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="l6" runat="server" Text='<%# Bind("day") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Status" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                           <asp:Label ID="l4" runat="server" Text='<%# Bind("astatus") %>' class="label label-info" Visible='<%#Eval("astatus").ToString()=="Pending"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("astatus") %>' class="label label-success" Visible='<%#Eval("astatus").ToString()=="Approved"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("astatus") %>' class="label label-important" Visible='<%#Eval("astatus").ToString()=="Rejected"?true:false%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Reason">
                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            <ItemStyle CssClass="" Width="40%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="l7" runat="server" Text='<%# Bind("reason") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View" HeaderStyle-Width="10%" Visible="false">
                                                        <ItemTemplate>
                                                            <%#linkleave(DataBinder.Eval(Container.DataItem, "empcode").ToString(), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "id")), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "Approval_status")))%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <%--<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="sp_od_fetchodsummary_approver"
                                                SelectCommandType="StoredProcedure">
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
                                                    <asp:SessionParameter DefaultValue="" Name="empcode" SessionField="empcode" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>--%>
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


