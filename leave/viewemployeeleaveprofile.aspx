<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewemployeeleaveprofile.aspx.cs" Inherits="leave_viewemployeeleaveprofile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />

</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <%--<h2>View Employee Leave Profile</h2>--%>
                        <h2>Employee Leave Profile</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="widget">
                        <div class="widget-header">
                            <div class="title">
                                <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Employee Leave Profile--%>
                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                            </div>
                        </div>
                        <div class="widget-body">
                            <fieldset>
                                <div class="control-group">
                                    <label class="control-label span3">Employee Code</label>
                                    <div class="controls span3">
                                        <asp:Label ID="lbl_empcode" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
                <div class="row-fluid" style="display: none">
                    <div class="widget">
                        <div class="widget-header">
                            <div class="title">
                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Approver Level
                            </div>
                        </div>
                        <div class="widget-body">
                            <div id="dt_example" class="example_alt_pagination">
                                <asp:GridView ID="approvalgrid" runat="server"
                                    AutoGenerateColumns="False"
                                    CssClass="table table-striped table-bordered table-hover table-checkable table-responsive " OnPreRender="approvalgrid_PreRender">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Emp Code" HeaderStyle-Width="24%">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Approver Name" HeaderStyle-Width="24%">
                                            <ItemTemplate>
                                                <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Level" HeaderStyle-Width="24%">
                                            <ItemTemplate>
                                                <asp:Label ID="l1" runat="server" Text='<%# Bind ("level") %>'></asp:Label>
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
                <div class="row-fluid" style="display: none">
                    <div class="widget">
                        <div class="widget-header">
                            <div class="title">
                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>HR
                            </div>
                        </div>
                        <div class="widget-body">
                            <fieldset>
                                <div class="control-group">
                                    <label class="control-label span3">HR</label>
                                    <div class="controls span3">
                                        <asp:Label ID="lbl_hr" runat="server"></asp:Label>
                                    </div>
                                    <div class="controls span3">
                                        <asp:Label ID="lbl_hr_name" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="widget">
                        <div class="widget-header">
                            <div class="title">
                                <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Set Leave Rule--%>
                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Leave Balance
                            </div>
                        </div>
                        <div class="widget-body">
                            <div id="Div1" class="example_alt_pagination">
                                <asp:GridView ID="grid_customizerule" runat="server"
                                    CssClass="table table-striped table-bordered table-hover table-checkable table-responsive" OnPreRender="grid_customizerule_PreRender"
                                    DataKeyNames="leaveid" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Leave Type" HeaderStyle-Width="10%">

                                            <ItemTemplate>
                                                <asp:Label ID="l2" runat="server" Text='<%# Bind ("leavetype") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Entitled Days" HeaderStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="l6" runat="server" Text='<%# Bind ("Expr4") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="leaveid" Visible="false" HeaderStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("leaveid") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Policy Id" Visible="false" HeaderStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="l5" runat="server" Text='<%# Bind ("PolicyId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>

                                <div class="clearfix"></div>

                                <div class="form-actions no-margin">
                                    <asp:Button ID="btn_back" runat="server" CssClass="btn btn-primary pull-right" Style="text-align: right" Text="Back" title="Go Back" OnClick="btn_back_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
               

            </div>
        </div>
    </form>
</body>
</html>
