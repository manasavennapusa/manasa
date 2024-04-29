<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editattendancerule.aspx.cs" Inherits="attendance_editattendancerule" %>

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
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Attendance Rule
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="rulegrid" runat="server" AutoGenerateColumns="False"
                                        CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                        OnPreRender="rulegrid_PreRender" DataKeyNames="slno">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Shift Name" HeaderStyle-Width="20%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%#Bind("shiftname")%>'> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Early In" HeaderStyle-Width="15%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l2" runat="server" Text='<%#Bind("earlyin")%>'> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Late In" HeaderStyle-Width="15%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%#Bind("latein")%>'> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Early Out" HeaderStyle-Width="15%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l4" runat="server" Text='<%#Bind("earlyout")%>'> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Late Out" HeaderStyle-Width="15%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l5" runat="server" Text='<%#Bind("lateout")%>'> </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="15%">
                                                <ItemTemplate>
                                                    <a href="UpdateAttendanceRule.aspx?id=<%#DataBinder.Eval(Container.DataItem,"slno")%>" target="_self">
                                                        <i class="icon-pencil"></i>
                                                    </a>
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
                $('#rulegrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>

