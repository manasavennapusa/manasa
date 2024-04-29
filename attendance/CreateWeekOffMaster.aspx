<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateWeekOffMaster.aspx.cs" Inherits="attendance_CreateWeekOffMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                    <div class="page-header">
                        <div class="pull-left">
                            <h2>Week Off</h2>
                        </div>

                        <div class="clearfix"></div>
                    </div>

                    <div class="row-fluid">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Create Week Off
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>

                                    <div class="control-group">
                                        <label class="control-label">Work Location</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddbranch_id" runat="server" CssClass="span3" AutoPostBack="true" OnSelectedIndexChanged="ddbranch_id_SelectedIndexChanged">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Week Off</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddlweekoff" runat="server" Width="" CssClass="span3" ToolTip="Select Week Off">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="btn btn-info " OnClick="btnsbmit_Click" />
                                    </div>

                                </fieldset>
                            </div>

                        </div>
                    </div>

                    <div class="row-fluid">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Week Off
                                </div>
                            </div>
                            <div class="widget-body">
                                   <%-- <div class="fontrol-group">--%>
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="weekoffgrid" runat="server"  AutoGenerateColumns="False" DataKeyNames="weekoffid"
                                                CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                OnRowDeleting="weekoffgrid_RowDeleting"
                                                OnPreRender="weekoffgrid_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Wekk Off Id" HeaderStyle-Width="16%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind("weekoffid")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Work Location" HeaderStyle-Width="16%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind("branch_name")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Week Off Code" HeaderStyle-Width="32%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind("weekcode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Week Off Name" HeaderStyle-Width="16%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("weekname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="l5" runat="server" CommandName="Delete" CssClass="link05" OnClientClick="return confirm('Are you sure, you want to delete the record?');"><i class="icon-remove"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>

                                            </asp:GridView>
                                            <div class="clearfix"></div>
                                        <%--</div>--%>
                                    </div>
                            </div>

                        </div>
                    </div>

                </div>
            </div>
        </div>
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
