<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editleaveadjustmentRule.aspx.cs" Inherits="leave_editleaveadjustmentRule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script type="text/javascript">
        function ValidateAdjustLeave() {
            var ladjleave = document.getElementById('<%=drp_aleave.ClientID%>');
             if (ladjleave.value == 100) {
                 alert("Please select adjust leave type");
                 return false;

             }

             return true;
         }
    </script>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
              <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
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
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Edit Adjustment Leave Rule
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
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label span3">Adjustment Leave</label>
                                            <div class="controls span2">
                                                <asp:DropDownList ID="drp_aleave" runat="server" CssClass="span3"  Width="220px" OnDataBound="drp_aleave_DataBound">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="span2">
                                                <asp:Button ID="btm_add" runat="server" Text="Add" CssClass="btn btn-info pull-right " OnClick="btm_add_Click" OnClientClick="return ValidateAdjustLeave();" />
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                        <div class="widget-body">
                            <div id="dt_example" class="example_alt_pagination">
                                <asp:GridView ID="grid_aleave" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="aleaveid" OnPreRender="grid_aleave_PreRender" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive"
                                    OnRowDeleting="grid_aleave_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Leave Name" HeaderStyle-Width="25%">
                                            <ItemTemplate>
                                                <asp:Label ID="l3" runat="server" Text='<%# Bind("aleavename")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete" CssClass="link05"
                                                    OnClientClick="return confirm(' Do you want to Delete this record?');"><i class="icon-remove"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle Height="5px" />
                                </asp:GridView>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                        <div class="form-actions no-margin">
                            <asp:Button ID="btn_submit" runat="server" CssClass="btn btn-info  " Text="Update" OnClick="btn_submit_Click" ToolTip="Click here to submit the updated rule" />
                            <asp:Button ID="btnrst" runat="server" CssClass="btn btn-info  " OnClick="btnrst_Click" Text="Cancel" ToolTip="Click here to cancel the updation" />
                            <asp:HiddenField ID="hiddenvalue" runat="server" />
                            <asp:HiddenField ID="hidden_policy" runat="server" />
                        </div>
                    <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
    </form>
</body>
</html>
