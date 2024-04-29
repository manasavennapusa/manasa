<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leaveapprovalproxy.aspx.cs" Inherits="leave_leaveapprovalproxy" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <script src="js/popup.js"></script>
    <%--<script src="Js/popup.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>
                                          Assign Proxy Approver
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="leave_approval_grid" runat="server" OnRowUpdating="leave_approval_grid_RowUpdating" 
                                                AutoGenerateColumns="False" DataKeyNames="id" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" OnPreRender="leave_approval_grid_PreRender">
                                                <Columns>
                                                     <asp:TemplateField HeaderText="Id" Visible="false">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblapplyid" runat="server" Text='<%# Bind("id")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Code">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempcode" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Employee Name">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind("empname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approver Code">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblapprovercode" runat="server" Text='<%# Bind("approverid")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Approver Name">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("approvername")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Level">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                              <asp:Label ID="lbllevel" runat="server" Text='<%# Eval("level").ToString()%>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lbll" runat="server" Text='<%#"Level"+""+ Eval("level").ToString()%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Leave Type">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                        <ItemStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblleavaetype" runat="server" Text='<%# Bind("leavename") %>'></asp:Label>
                                                            <%-- <%#linkleave(DataBinder.Eval(Container.DataItem, "empcode").ToString(),DataBinder.Eval(Container.DataItem, "leavename").ToString(), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "id")))%>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Leave Status">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl4" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-info" Visible='<%#Eval("leavestatus").ToString()=="Pending"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-important" Visible='<%#Eval("leavestatus").ToString()=="Rejected"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-warning" Visible='<%#Eval("leavestatus").ToString()=="Approved,not Updated by HR"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-warning" Visible='<%#Eval("leavestatus").ToString()=="Cancelled"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-success" Visible='<%#Eval("leavestatus").ToString()=="Approved and Updated by HR"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-info" Visible='<%#Eval("leavestatus").ToString()=="Pending for Cancellation"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-info" Visible='<%#Eval("leavestatus").ToString()=="Pending for Modification"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-warning" Visible='<%#Eval("leavestatus").ToString()=="Back to User"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("leavestatus") %>' class="label label-success" Visible='<%#Eval("leavestatus").ToString()=="Approved"?true:false%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Select Proxy Employee">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                        <ItemStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="span6" Enabled="false"></asp:TextBox>
                                                            <a href="JavaScript:newPopup1('pickproxyapprover.aspx?level=<%# Eval("level") %>&sno=<%#Container.DataItemIndex %>');"><i class="icon-user"></i></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Submit">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                        <ItemStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnlsubmit" Visible="" DataNavigateUrlFields="empcode" runat="server" Text="Assign" CommandName="Update" PostBackUrl="leaveapprovalproxy.aspx?empcode=0"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="From Date">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("fromdate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="To Date">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l6" runat="server" Text='<%# Bind("todate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="No of Days">
                                                        <HeaderStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemStyle CssClass="" HorizontalAlign="Left" VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l7" runat="server" Text='<%# Bind("nod") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" runat="server" SelectCommand="sp_leave_getproxyleavedetails" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
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

