<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewcompoffapprover.aspx.cs" Inherits="leave_viewcompoffapprover" %>

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
                                    <h2>Comp-off Leave</h2>
                                </div>
                                
                                <div class="clearfix"></div>
                            </div>
                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Information
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <div class="controls controls-row">
                                                    <label class="control-label span3 ">Employee Name</label>
                                                    <div class="controls span3">
                                                        <asp:Label ID="lbl_emp_name" runat="server"></asp:Label>
                                                    </div>
                                                    <label class="control-label span3">Gender</label>
                                                    <div class="controls span3">
                                                        <asp:Label ID="lbl_gender" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <div class="controls controls-row">
                                                    <label class="control-label span3 ">Employee Code</label>
                                                    <div class="span3">
                                                        <asp:Label ID="lbl_emp_code" runat="server"></asp:Label>
                                                    </div>
                                                    <label class="control-label span3">Branch</label>
                                                    <div class="controls span3">
                                                        <asp:Label ID="lbl_branch" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <div class="controls controls-row">
                                                    <label class="control-label span3 ">Department</label>
                                                    <div class="span3">
                                                        <asp:Label ID="lbl_dept" runat="server"></asp:Label>
                                                    </div>
                                                    <label class="control-label span3">D.O.J</label>
                                                    <div class="span3">
                                                        <asp:Label ID="lbl_doj" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <div class="controls controls-row">
                                                    <label class="control-label span3 ">Designation</label>
                                                    <div class="span3">
                                                        <asp:Label ID="lbl_designation" runat="server"></asp:Label>
                                                    </div>
                                                    <label class="control-label span3">Status</label>
                                                    <div class="span3">
                                                        <asp:Label ID="lbl_status" runat="server"></asp:Label>
                                                    </div>
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
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Comp-off Application
                                
                                        </div>
                                        <a href="#myModal" role="button" class="btn btn-info pull-right pull-right" data-toggle="modal">Comp-off Status</a>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>

                                            <div>
                                                <div class="control-group">
                                                    <label class="control-label span3">From Date</label>
                                                    <div class="controls span3">
                                                        <asp:Label ID="lbl_fromdate" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label span3">To Date</label>
                                                    <div class="controls span3">
                                                        <asp:Label ID="lbl_todate" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">No. of Days</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_nodays" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label span3">Reason</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_reason" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Approver Hierarchy
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="Div2" class="example_alt_pagination">
                                            <asp:GridView ID="approvergrid" runat="server"
                                                CellPadding="4" Width="100%" AutoGenerateColumns="False"
                                                EmptyDataText="No leave to adjust" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                DataKeyNames="empcode">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Employee Code">
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                                        <ItemStyle Width="33%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approver Name">
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                                        <ItemStyle Width="33%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Level">
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                                        <ItemStyle Width="33%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("status") %>' class="label label-info" Visible='<%#Eval("status").ToString()=="Pending with approver"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("status") %>' class="label label-important" Visible='<%#Eval("status").ToString()=="Rejected by approver"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("status") %>' class="label label-success" Visible='<%#Eval("status").ToString()=="Approved with approver"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("status") %>' class="label label-info" Visible='<%#Eval("status").ToString()=="Pending with HR"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("status") %>' class="label label-success" Visible='<%#Eval("status").ToString()=="Approved by HR"?true:false%>'></asp:Label>
                                                            
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:HiddenField ID="hidd_leaveapplyid" runat="server" Value="0" />
                                            <asp:HiddenField ID="hidd_leaveid" runat="server" />
                                            <asp:HiddenField ID="prvimg" runat="server" />
                                            <asp:HiddenField ID="hidd_empcode" runat="server" Value="0" />
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label span3">Previous Comment</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_comments" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Add Comment</label>
                                                <div class="controls span3">
                                                    <asp:TextBox ID="txt_comment" runat="server" CssClass="span3" Width="220px" TextMode="MultiLine"
                                                        Height="40px"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btn_approve" runat="server" Style="margin-right: 5px" CssClass="btn btn-info pull-right" OnClick="btn_approve_Click"
                                                    Text="Approve" />&nbsp;&nbsp;<asp:Button ID="btn_backuser" Style="margin-right: 5px" runat="server" CssClass="btn btn-info pull-right" OnClick="btn_backuser_Click" Visible="false"
                                                        Text="Back to User" />&nbsp;&nbsp;<asp:Button ID="btn_cancel" Style="margin-right: 5px" runat="server" CssClass="btn btn-info pull-right" OnClick="btn_cancel_Click"
                                                            Text="Reject" />
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                ×
                            </button>
                            <h4 id="myModalLabel">Comp-off Balance
                            </h4>
                        </div>
                        <div class="modal-body">
                            <table width="100%" class="table table-condensed table-striped table-hover table-bordered pull-left">
                                <tr>
                                    <td class="txt02">Entitled</td>
                                    <td class="txt02">Used</td>
                                    <td class="txt02">Available</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblentitled" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblused" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblavalible" runat="server"></asp:Label></td>
                                </tr>

                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.js"></script>
        <script src="../js/moment.js"></script>
        <!-- Custom Js -->
        <script src="../js/theming.js"></script>
        <%--  <script src="../js/custom.js"></script>--%>
    </form>
</body>
</html>


