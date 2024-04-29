<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editleaverule.aspx.cs" Inherits="leave_editleaverule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
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
                <div class="page-header">
                    <div class="pull-left">
                        <h2>Leave Rule</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Leave Rules--%>
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View/Edit
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="rulegrid" runat="server" AutoGenerateColumns="False"
                                                DataKeyNames="id" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                OnPreRender="rulegrid_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Policy Name" HeaderStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%#Bind("policyname")%>'> </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Leave Name" HeaderStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%#Bind("leavetype")%>'> </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="General Rule" HeaderStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <a href="ViewLeaveRule.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>" class="link05"><i class="icon-search"></i></a>|
                                        <a href="UpdateLeaveRule.aspx?id=<%#DataBinder.Eval(Container.DataItem,"id")%>" class="link05" target="_self"><i class="icon-pencil"></i></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Adjustment Rule" HeaderStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <a href="ViewLeaveAdjustmentRule.aspx?leaveid=<%#DataBinder.Eval(Container.DataItem,"leaveid")%>&policyid=<%#DataBinder.Eval(Container.DataItem,"policyid")%>" class="link05"><i class="icon-search"></i></a>|
                                        <a href="EditLeaveAdjustmentRule.aspx?leaveid=<%#DataBinder.Eval(Container.DataItem, "leaveid")%>&policyid=<%#DataBinder.Eval(Container.DataItem,"policyid")%>" target="_self" class="link05"><i class="icon-pencil"></i></a>
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
                    <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
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

