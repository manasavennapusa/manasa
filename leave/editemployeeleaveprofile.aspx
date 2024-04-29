<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editemployeeleaveprofile.aspx.cs" Inherits="leave_editemployeeleaveprofile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                <div class="page-header">
                    <div class="pull-left">
                        <%--<h2>Create Leave</h2>--%>
                        <h2>Employee Leave Profile</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Leave Profile--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View/Edit
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <div class="controls controls-row">
                                            <label class="control-label span3">Work Location</label>
                                            <div class="controls span3">
                                                <asp:DropDownList ID="ddl_branch" runat="server" CssClass="span3" Width="220px" Height=""
                                                    DataSourceID="sql_data_branch" DataTextField="branch_name" DataValueField="Branch_Id"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged" OnDataBound="ddl_branch_DataBound">
                                                </asp:DropDownList>
                                                <asp:SqlDataSource
                                                    ID="sql_data_branch" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail]"></asp:SqlDataSource>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="empgird" runat="server" DataKeyNames="empcode" AutoGenerateColumns="False"
                                        CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" OnPreRender="empgird_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Employee Code"
                                                HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="25%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="22%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department" HeaderStyle-Width="22%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Role">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l5" runat="server" Text='<%# Bind ("role") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <a href="ViewEmployeeLeaveProfile.aspx?empcode=<%#DataBinder.Eval(Container.DataItem, "empcode")%>" class="link05"><i class="icon-search"></i></a>|
                                                    <a href="UpdateEmployeeLeaveProfile.aspx?empcode=<%#DataBinder.Eval(Container.DataItem, "empcode")%>" class="link05"><i class="icon-pencil"></i></a>
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
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#empgird').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>


