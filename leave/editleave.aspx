<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editleave.aspx.cs" Inherits="leave_editleave" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                 <div class="page-header">
                    <div class="pull-left">
                        <h2>Leave Master</h2>
                    </div>    
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Leave--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="leavegird" runat="server" DataKeyNames="leaveid" AutoGenerateColumns="False" OnRowEditing="shiftgrid_RowEditing" OnRowDeleting="shiftgrid_RowDeleting"
                                        CssClass="table table-condensed table-striped table-hover table-bordered pull-left" OnPreRender="leavegird_PreRender">
                                        <Columns>
                                            <asp:BoundField DataField="leaveid" HeaderText="Leave Id" InsertVisible="False" ReadOnly="True"
                                                SortExpression="leaveid" />
                                            <asp:BoundField DataField="leavetype" HeaderText="Leave Name" SortExpression="leavetype" HeaderStyle-Width="25%"></asp:BoundField>
                                            <asp:BoundField DataField="displayleave" HeaderText="Display Leave" SortExpression="displayleave" HeaderStyle-Width="15%"></asp:BoundField>
                                            <asp:BoundField DataField="description" HeaderText="Description" SortExpression="Description" HeaderStyle-Width="45%"></asp:BoundField>
                                            <asp:TemplateField HeaderStyle-Width="15%">
                                                <ItemTemplate>
                                                    <a class="link05" href="updateleave.aspx?leaveid=<%#DataBinder.Eval(Container.DataItem, "leaveid")%>" target="_self">
                                                        <i class="icon-pencil"></i></a>|
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');"><i class="icon-remove"></i></asp:LinkButton>
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
                $('#leavegird').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>
