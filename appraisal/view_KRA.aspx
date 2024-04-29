<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_KRA.aspx.cs" Inherits="appraisal_view_KRA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="background-color: white">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px; background-color: white">
            <div class="main-container">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>My Leave Balance--%>
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="Grid" runat="server"
                                                AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                OnPreRender="Grid_PreRender">
                                                <RowStyle Height="5px" />

                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sl.No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex +1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="5%" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Name of the Goal">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Labelspe1" runat="Server" Text='<%# Eval("role_name_of_the_goal") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Desired outcome/Impact">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Labelspe2" runat="Server" Text='<%# Eval("kca_kra_desired_outcome_impact") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20%" />
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Milestone to check improvement">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Labelspe3" runat="Server" Text='<%# Eval("kpi_milestone_to_check_improvement") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20%" />
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Timeline and support required">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Labelspe4" runat="Server" Text='<%# Eval("weightage_timeline_and_support_required") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20%" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" runat="server" SelectCommand="sp_leave_myballeave" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                                    <asp:ControlParameter ControlID="hidd_empcode" Name="empcode" PropertyName="Value"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <asp:HiddenField ID="hidd_empcode" runat="server" />
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
    </form>
</body>
</html>
