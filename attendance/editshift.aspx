<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editshift.aspx.cs" Inherits="attendance_editshift" %>

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
                <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Search
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label span3">Select Work Location</label>
                                        <div class="controls span3">
                                            <asp:DropDownList ID="ddselbranch" runat="server" CssClass="blue1" DataSourceID="SqlDataSource1"
                                                DataTextField="branch_name" DataValueField="branch_id" OnDataBound="ddselbranch_DataBound"
                                                OnSelectedIndexChanged="ddselbranch_SelectedIndexChanged" Width="" AutoPostBack="True">
                                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                DeleteCommand="DELETE FROM [tbl_intranet_branch_detail] WHERE [branch_id] = @branch_id"
                                                InsertCommand="INSERT INTO [tbl_intranet_branch_detail] ([branch_id], [branch_name]) VALUES (@branch_id, @branch_name)"
                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]"
                                                UpdateCommand="UPDATE [tbl_intranet_branch_detail] SET [branch_name] = @branch_name WHERE [branch_id] = @branch_id">
                                                <DeleteParameters>
                                                    <asp:Parameter Name="branch_id" Type="Int32" />
                                                </DeleteParameters>
                                                <UpdateParameters>
                                                    <asp:Parameter Name="branch_name" Type="String" />
                                                    <asp:Parameter Name="branch_id" Type="Int32" />
                                                </UpdateParameters>
                                                <InsertParameters>
                                                    <asp:Parameter Name="branch_id" Type="Int32" />
                                                    <asp:Parameter Name="branch_name" Type="String" />
                                                </InsertParameters>
                                            </asp:SqlDataSource>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Shift
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="shiftgrid" runat="server" 
                                        AutoGenerateColumns="False" 
                                        DataKeyNames="shiftid" 
                                        CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                        OnRowEditing="shiftgrid_RowEditing"  
                                        OnRowDeleting="shiftgrid_RowDeleting" 
                                        OnPreRender="shiftgrid_PreRender">
                                        <Columns>
                                           
                                             <asp:TemplateField HeaderText="Work Location " HeaderStyle-Width="20%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Shift Id" HeaderStyle-Width="20%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l0" runat="server" Text='<%# Bind ("shiftid") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Shift Name" HeaderStyle-Width="13%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lsss" runat="server" Text='<%# Bind ("shiftname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Start Time" HeaderStyle-Width="12%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind("starttime")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="End Time" HeaderStyle-Width="12%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l5" runat="server" Text='<%# Bind("endtime")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description" HeaderStyle-Width="20%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind("shift_description")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="15%" HeaderText="Edit">
                                                <ItemTemplate>
                                                    <a class="link05" href="updateshift.aspx?shiftid=<%#DataBinder.Eval(Container.DataItem, "shiftid")%>"
                                                        target="_self"><i class="icon-pencil"></i></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="15%" HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" CssClass="link05"
                                                        OnClientClick="return confirm(' Do you want to Delete this record?');"><i class="icon-remove"></i></asp:LinkButton>
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
            </div>

        </div>
        <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>

        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#shiftgrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>
