<%@ Page Language="C#" AutoEventWireup="true" CodeFile="compoffstatus.aspx.cs" Inherits="leave_compoffstatus" %>



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
               <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                    <div class="page-header">
                        <div class="pull-left">
                            <h2>Comp-Off Status</h2>
                        </div>

                        <div class="clearfix"></div>
                    </div>

                    <div class="row-fluid">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Search Employee
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                   <%-- <div class="control-group">
                                        <label class="control-label">From Date</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_sdate" runat="server" CssClass="span3" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                            <cc1:CalendarExtender
                                                ID="CalendarExtender1" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>--%>
                                  <%--  <div class="control-group">
                                        <label class="control-label">To Date </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_edate" runat="server" CssClass="span3" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                            <cc1:CalendarExtender
                                                ID="CalendarExtender2" runat="server" PopupButtonID="Image1" TargetControlID="txt_edate">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>--%>
                                    <div class="control-group">
                                        <label class="control-label">Comp-Off Status </label>
                                        <div class="controls">
                                            <asp:DropDownList ID="drp_leavestatus" runat="server" CssClass="span3" Width="" OnSelectedIndexChanged="drp_leavestatus_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0">Pending</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="1">Approved</asp:ListItem>
                                                <asp:ListItem Value="2">Cancelled</asp:ListItem>
                                                <asp:ListItem Value="3">Rejected</asp:ListItem>
                                               
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                  <%--  <div class="control-group">
                                        <label class="control-label">Employee Name\Code</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_empcode" runat="server" CssClass="span3" Width="" onkeypress="return isAlphaNumeric()"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Work Location</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="drpbranch" runat="server" CssClass="blue1" Height=""
                                                DataSourceID="sql_data_branch" DataTextField="branch_name" DataValueField="Branch_Id"
                                                OnDataBound="drpbranch_DataBound" AutoPostBack="True" OnSelectedIndexChanged="drpbranch_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource
                                                ID="sql_data_branch" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail]"></asp:SqlDataSource>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Department</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="drpdepartment" runat="server" CssClass="blue1" Height=""
                                                OnDataBound="drpdepartment_DataBound">
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                                    <div class="form-actions no-margin">
                                      <%--   <asp:Button ID="btn_search" runat="server" CssClass="btn btn-info" OnClick="btn_search_Click" Text="Search" OnClientClick="return ValidateData();" />
                                       <asp:Button ID="btn_export" runat="server" CssClass="btn btn-info" OnClick="btn_export_Click" Text="Export" OnClientClick="return ValidateData();" />
                                        <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info" OnClick="btn_reset_Click" Text="Reset" ValidationGroup="c" />--%>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                        <div class="row-fluid">

                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>
                                            <asp:Label ID="Label1" runat="server" Text="View"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="leave_approval_grid" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                DataKeyNames="id" OnPreRender="leave_approval_grid_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Leave Type"
                                                        HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <%#linkleave(DataBinder.Eval(Container.DataItem, "empcode").ToString(), Convert.ToString(("Comp-off Leave")), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "id")), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "approval_status")))%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Leave Status"
                                                        HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-info" Visible='<%#Eval("leavestatus").ToString()=="Pending"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-important" Visible='<%#Eval("leavestatus").ToString()=="Rejected"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-primary" Visible='<%#Eval("leavestatus").ToString()=="Approved,not Updated by HR"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-warning" Visible='<%#Eval("leavestatus").ToString()=="Cancelled"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-success" Visible='<%#Eval("leavestatus").ToString()=="Approved and Updated by HR"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-info" Visible='<%#Eval("leavestatus").ToString()=="Pending for Cancellation"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-info" Visible='<%#Eval("leavestatus").ToString()=="Pending for Modification"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-warning" Visible='<%#Eval("leavestatus").ToString()=="Back to User"?true:false%>'></asp:Label>
                                                             <asp:Label ID="Label9" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-success" Visible='<%#Eval("leavestatus").ToString()=="Approved"?true:false%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="From Date"
                                                        HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("fromdate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="To Date"
                                                        HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l6" runat="server" Text='<%# Bind("todate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="No of Days"
                                                        HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l7" runat="server" Text='<%# Bind("nod") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                         <%--   <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                DeleteCommand="DELETE FROM [tbl_leave_createleave] WHERE [leaveid] = @leaveid"
                                                InsertCommand="INSERT INTO [tbl_leave_createleave] ([leavetype]) VALUES (@leavetype)"
                                                ProviderName="System.Data.SqlClient" SelectCommand="sp_leave_fetchcompoff_summary_user"
                                                SelectCommandType="StoredProcedure" UpdateCommand="UPDATE [tbl_leave_createleave] SET [leavetype] = @leavetype WHERE [leaveid] = @leaveid">
                                                <DeleteParameters>
                                                    <asp:Parameter Name="leaveid" Type="Int32" />
                                                </DeleteParameters>
                                                <UpdateParameters>
                                                    <asp:Parameter Name="leavetype" Type="String" />
                                                    <asp:Parameter Name="leaveid" Type="Int32" />
                                                </UpdateParameters>
                                                <InsertParameters>
                                                    <asp:Parameter Name="leavetype" Type="String" />
                                                </InsertParameters>
                                                <SelectParameters>
                                                    <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                                    <asp:SessionParameter DefaultValue="0" Name="empcode" SessionField="empcode" Type="String" />
                                                    <asp:QueryStringParameter DefaultValue="0" Name="compoffstatus" QueryStringField="compoffstatus"
                                                        Type="Int32" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>--%>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                <%--    </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#leave_approval_grid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>



