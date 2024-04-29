<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editholiday.aspx.cs" Inherits="attendance_editholiday" %>

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
                                        <label class="control-label span3">Select WorkLocation</label>
                                        <div class="controls span3">
                                            <asp:DropDownList ID="ddselbranch" runat="server" CssClass="blue1" DataSourceID="SqlDataSource1"
                                                DataTextField="branch_name" DataValueField="branch_id" OnDataBound="ddlbranch_DataBound1"
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
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Holiday List
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="holidaygrid" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="holidayid"
                                        CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" OnPageIndexChanging="holidaygrid_PageIndexChanging"
                                        OnRowDeleting="holidaygrid_RowDeleting" OnRowEditing="holidaygrid_RowEditing" OnPreRender="holidaygrid_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Work Location" HeaderStyle-Width="16%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind("branch_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name" HeaderStyle-Width="32%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind("name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date" HeaderStyle-Width="16%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l411" runat="server" Text='<%# Bind("date")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Day of Week" HeaderStyle-Width="16%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l41" runat="server" Text='<%# Bind("dayofweek")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="20%">
                                                <ItemTemplate>
                                                    <a class="link05" href="updateholiday.aspx?holidayid=<%#DataBinder.Eval(Container.DataItem, "holidayid")%>"
                                                        target="_self"><i class="icon-pencil"></i></a>|
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
                $('#holidaygrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>

