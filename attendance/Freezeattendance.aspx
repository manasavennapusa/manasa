<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Freezeattendance.aspx.cs" Inherits="attendance_Freezeattendance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Apply Leave</title>
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
                                        <label class="control-label span3">Year</label>
                                        <div class="controls span3">
                                            <asp:DropDownList ID="dd_year" runat="server" Width="129px" ToolTip="Financial Year"
                                                CssClass="blue1" DataTextField="year" DataValueField="year" AutoPostBack="True"
                                                OnSelectedIndexChanged="dd_year_SelectedIndexChanged">
                                            </asp:DropDownList>
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
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Freeze Attendance
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="gd_encash" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                        CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" OnPreRender="gd_encash_PreRender" OnRowEditing="gd_encash_RowEditing">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl. No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex  + 1  %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Year">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblYear" runat="server" Text='<%# Bind ("YEAR") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Month">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMonth" runat="server" Text='<%# Bind ("MONTH") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="lblStatus" runat="server" Text='<%# Bind ("Status") %>'></asp:Label>--%>
                                               <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>' class="label label-success"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" Text='<%# Bind("free_status") %>' style="color:#729ce0"></asp:LinkButton>
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
                $('#gd_encash').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>
