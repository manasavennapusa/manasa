<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editweekoff.aspx.cs" Inherits="attendance_editweekoff" %>

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
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Week Off List
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="weekoffgrid" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="weekoffid" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" OnPageIndexChanging="holidaygrid_PageIndexChanging"
                                        OnRowDeleting="holidaygrid_RowDeleting" OnRowEditing="holidaygrid_RowEditing" OnPreRender="weekoffgrid_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Week Code" HeaderStyle-Width="16%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind("weekcode")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Week Name" HeaderStyle-Width="32%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind("weekname")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderStyle-Width="20%" HeaderText="Edit">
                                                <ItemTemplate>
                                                    <a class="link05" href="UpdateWeekoff.aspx?weekoffid=<%#DataBinder.Eval(Container.DataItem, "weekoffid")%>"
                                                        target="_self"><i class="icon-pencil"></i></a>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="20%" HeaderText="Delete">
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
                $('#weekoffgrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>

