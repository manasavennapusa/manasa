<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewleavehr.aspx.cs" Inherits="leave_viewleavehr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
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
                                    <h2>View Leave By HR</h2>
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
                                                        <asp:Label ID="lbl_department" runat="server"></asp:Label>
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
                                                        <asp:Label ID="lbl_emp_status" runat="server"></asp:Label>
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
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Leave Application
                                        </div>
                                        <a data-toggle="modal" href="#myModal1" class="btn btn-info pull-right pull-right">Leave Status</a>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label span3">Type of Leave</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_leave" runat="server"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="control-group" id="div_Furnelleave" visible="false" runat="server">
                                                <label class="control-label span3">Relation</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lblrelation" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div id="divfull" visible="true" runat="server">
                                                <div class="control-group">
                                                    <label class="control-label span3">From Date</label>
                                                    <div class="controls span3">
                                                        <asp:Label ID="lbl_sdate" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label span3">To Date</label>
                                                    <div class="controls span3">
                                                        <asp:Label ID="lbl_edate" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="divhalf" visible="false" runat="server">
                                                <div class="control-group">
                                                    <label class="control-label span3">Half Day Mode</label>
                                                    <div class="controls span3">
                                                        <asp:Label ID="lbl_half" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label span3">Select Date</label>
                                                    <div class="controls span3">
                                                        <asp:Label ID="lbl_select" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">No. of Days</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_nod" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Leave Adjustment
                                        </div>
                                    </div>
                                    <div class="widget-body" style="display: none">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label span3">Type of Leave </label>
                                                <div class="controls span3">
                                                    <asp:DropDownList ID="drp_leave" runat="server" CssClass="span3" Width="220px" DataSourceID="SqlDataSource1" DataTextField="leavetype" DataValueField="leaveid">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="select  DISTINCT  crleave.leaveid,crleave.leavetype from tbl_leave_createleave crleave INNER JOIN tbl_leave_employee_leave_master elm ON elm.leaveid=crleave.leaveid INNER JOIN tbl_leave_createdefaultrule r ON r.leaveid = elm.leaveid where elm.empcode=@empcode and crleave.leaveid not in (0) and ( applicable_to = 'A' or applicable_to = @gender ) and r.company_id=@companyid order by crleave.leavetype"
                                                        UpdateCommand="UPDATE [tbl_leave_createleave] SET [leavetype] = @leavetype WHERE [leaveid] = @leaveid">
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
                                                            <%--  <asp:SessionParameter Name="empcode" SessionField="empcode" />--%>
                                                            <asp:SessionParameter Name="companyid" SessionField="companyid" />
                                                            <%--<asp:SessionParameter Name="gender" SessionField="gender" />--%>
                                                            <asp:ControlParameter ControlID="HiddenField_gender" Name="gender" PropertyName="Value"
                                                                Type="String" />
                                                            <asp:ControlParameter ControlID="hidd_empcode" Name="empcode" PropertyName="Value"
                                                                Type="String" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">No. of Days</label>
                                                <div class="controls span3">
                                                    <asp:TextBox ID="txt_noofdays" CssClass="span3" Width="220px" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="controls span3">
                                                    <asp:Button ID="btn_add" runat="server" CssClass="btn btn-info pull-right " OnClick="btn_add_Click" Text="Add" OnClientClick="return validate();" />
                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="adjustgrid" runat="server"
                                                AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive " OnPreRender="adjustgrid_PreRender"
                                                DataKeyNames="leaveid">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Leave Type" HeaderStyle-Width="50%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("leavename") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="No. of Days" HeaderStyle-Width="50%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("noofdays") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l4" runat="server" Text='<%# Bind ("status") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label span3">Reason</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_reason" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Attachment (if any)</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_file" runat="server"></asp:Label>
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
                                            <asp:GridView ID="approvergrid" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-striped table-bordered table-hover table-checkable table-responsive" OnPreRender="approvergrid_PreRender"
                                                DataKeyNames="empcode">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Employee Code">
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                                        <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approver Name">
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                                        <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Level">
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                                        <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("Levels") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                                        <ItemStyle Width="35%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("status") %>' class="label label-info" Visible='<%#Eval("status").ToString()=="Pending with HR"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("status") %>' class="label label-info" Visible='<%#Eval("status").ToString()=="Pending with approver"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("status") %>' class="label label-important" Visible='<%#Eval("status").ToString()=="Rejected by approver"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("status") %>' class="label label-success" Visible='<%#Eval("status").ToString()=="Approved by HR"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("status") %>' class="label label-success" Visible='<%#Eval("status").ToString()=="Approved with approver"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("status") %>' class="label label-info" Visible='<%#Eval("status").ToString()=="Pending with Dotted Approver"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("status") %>' class="label label-success" Visible='<%#Eval("status").ToString()=="Approved with Dotted Approver"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("status") %>' class="label label-important" Visible='<%#Eval("status").ToString()=="Rejected by Dotted Approver"?true:false%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="" />
                                                <FooterStyle CssClass="" />
                                                <RowStyle Height="5px" />
                                            </asp:GridView>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label span3">Previous  Comments</label>
                                                <div class="controls span9">
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
                                                <asp:Button ID="btn_approve" runat="server" CssClass="btn btn-success pull-right " OnClick="btn_approve_Click" Text="Update" />
                                                <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info pull-right " Text="Reset" OnClick="btn_reset_Click" Visible="false" />
                                                <asp:Button ID="btncancel" runat="server" CssClass="btn btn-info pull-right " Text="Cancel" OnClick="btncancel_Click" Visible="false" />
                                                <asp:HiddenField ID="hidd_leaveapplyid" runat="server" Value="0" />
                                                <asp:HiddenField ID="hidd_empcode" runat="server" Value="0" />
                                                <asp:HiddenField ID="HiddenField_gender" runat="server" />
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                                <div class="modal fade" id="myModal1">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                <h4 class="modal-title">Leave Balance</h4>
                                            </div>
                                            <div class="modal-body">
                                                <iframe src="MyLeaveBalance.aspx?empcode=<%=hidd_empcode.Value%>" width="100%" frameborder="0" scrolling="yes" height="300px"></iframe>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.js"></script>
        <script src="../js/moment.js"></script>
        <!-- Custom Js -->
        <script src="../js/theming.js"></script>
    </form>
</body>
</html>
