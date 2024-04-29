<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewleaveadjustmentrule.aspx.cs" Inherits="leave_viewleaveadjustmentrule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Leave Adjustment Rule</h2>
                            </div>
                            
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span> Adjustment Leave Rule
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label span3">Policy Name</label>
                                            <div class="controls span3">
                                                <asp:Label ID="lbl_policy" runat="server" Text="Label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label span3">Leave Name</label>
                                            <div class="controls span3">
                                                <asp:Label ID="lbl_leave" runat="server" Text="Label"></asp:Label>
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
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Adjustment Leave
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="grid_aleave" runat="server" AutoGenerateColumns="False" DataKeyNames="aleaveid" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive"
                                            OnPreRender="grid_aleave_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Leave Name">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left"
                                                        VerticalAlign="Top" Width="25%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind("aleavename")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                            <FooterStyle CssClass="frm-lft-clr123" />
                                            <RowStyle Height="5px" />
                                        </asp:GridView>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
