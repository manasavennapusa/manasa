<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewapprovecompoff.aspx.cs" Inherits="leave_viewapprovecompoff" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <link href="js/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="myForm" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
            runat="server">
            <ProgressTemplate>
                <div class="modal-backdrop fade in">
                    <div class="center">
                        <img src="images/loader.gif" alt="" />
                        Please Wait...
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="page-header">
                                <div class="pull-left">
                                    <h2>Holidaywork for Approval or Rejection</h2>
                                </div>
                               
                                <div class="clearfix"></div>
                            </div>

                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="widget no-margin">
                                        <div class="widget-header">
                                            <div class="title">
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>
                                                Holidaywork for Approval or Rejection
                                            </div>
                                        </div>
                                        <div class="widget-body">
                                            <div id="dt_example" class="example_alt_pagination">
                                                <asp:GridView ID="leave_approval_grid"   CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                    runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                    DataKeyNames="id" OnPreRender="leave_approval_grid_PreRender"
                                                    PageSize="100" OnRowCommand="leave_approval_grid_RowCommand">
                                                    <HeaderStyle CssClass="" />
                                                    <FooterStyle CssClass="" />
                                                    <RowStyle Height="5px" />

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

                                                        <asp:TemplateField HeaderText="Reason">
                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            <ItemStyle CssClass="" Width="40%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="l7" runat="server" Text='<%# Bind("reason") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="">
                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            <ItemStyle CssClass="" Width="14%" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btn_ter" runat="server" CommandArgument='<%#Eval("id") + "," + Eval("empcode")+","+Eval("date")%>' CommandName="accept" CssClass="btn btn-small btn-success" Text="Accept" />&nbsp;l&nbsp;
                            <asp:LinkButton ID="Button1" runat="server" CommandArgument='<%#Eval("id") + "," + Eval("empcode")+","+Eval("date")%>' CommandName="reject" CssClass="btn btn-small btn-danger" Text="Reject" />
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
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
        <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.js"></script>
        <script src="../js/moment.js"></script>
        <!-- Custom Js -->
        <script src="../js/theming.js"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#leave_approval_grid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
        <%--  <script src="../js/custom.js"></script>--%>
    </form>
</body>
</html>



