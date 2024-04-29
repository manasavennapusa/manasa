<%@ Page Language="C#" AutoEventWireup="true" CodeFile="odapproval.aspx.cs" Inherits="leave_odapproval" %>

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
                                            View Pending OD
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="pendinggrid" runat="server" EmptyDataText="no od requests found!!." AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" OnPreRender="pendinggrid_PreRender" DataKeyNames="id" DataSourceID="SqlDataSource1">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Emp Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Name">
                                                        <ItemTemplate>
                                                             
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind("empname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="From Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind("date")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="To Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("fromtime")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Days">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l6" runat="server" Text='<%# Bind("working_hour")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="OD Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-info" Visible='<%#Eval("leavestatus").ToString()=="Pending"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-important" Visible='<%#Eval("leavestatus").ToString()=="Rejected"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-warning" Visible='<%#Eval("leavestatus").ToString()=="Approved,not Updated by HR"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-warning" Visible='<%#Eval("leavestatus").ToString()=="Cancelled"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-success" Visible='<%#Eval("leavestatus").ToString()=="Approved and Updated by HR"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-info" Visible='<%#Eval("leavestatus").ToString()=="Pending for Cancellation"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-info" Visible='<%#Eval("leavestatus").ToString()=="Pending for Modification"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-warning" Visible='<%#Eval("leavestatus").ToString()=="Back to User"?true:false%>'></asp:Label>

                                                            <%-- <asp:Label ID="l7" runat="server" Text='<%# Bind("leavestatus")%>'></asp:Label>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <%#linkleave(DataBinder.Eval(Container.DataItem, "empcode").ToString(), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "id")))%>
                                                            <%--<asp:Label ID="l1" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="" />
                                                <FooterStyle CssClass="" />
                                                <RowStyle Height="5px" />
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                                SelectCommand="sp_leave_fetchoddetail" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                                    <asp:SessionParameter Name="empcode" SessionField="empcode" Type="String" />
                                                    <%-- <asp:Parameter DefaultValue="0" Name="Leave_status" Type="Int32" />--%>
                                                    <asp:QueryStringParameter Name="hr" QueryStringField="hr" Type="Int32" />
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
                $('#pendinggrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>


