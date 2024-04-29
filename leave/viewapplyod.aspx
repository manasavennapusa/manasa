<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewapplyod.aspx.cs" Inherits="leave_viewapplyod" %>

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
                                    <h2>View OD Application</h2>
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
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>OD Application
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group" style="display: none">
                                                <label class="control-label span3">OD Type</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_OdType" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">OD Mode</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_OdMode" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div id="divfull" visible="true" runat="server">
                                                <div class="control-group">
                                                    <label class="control-label span3">From Date</label>
                                                    <div class="controls span3">
                                                        <asp:Label ID="lbl_date" runat="server" Text="Label"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label span3">To Date</label>
                                                    <div class="controls span3">
                                                        <asp:Label ID="lbl_todate" runat="server" Text="Label"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="divhalf" visible="false" runat="server">
                                                <div class="control-group">
                                                    <label class="control-label span3">Half Day Mode</label>
                                                    <div class="controls span3">
                                                        <asp:Label ID="lbl_HalfMode" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label span3">Select Date</label>
                                                    <div class="controls span3">
                                                        <asp:Label ID="lbl_hdate" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="fulltime" visible="false" runat="server">
                                                <div class="control-group">
                                                    <label class="control-label span3">From Time</label>
                                                    <div class="controls span3">
                                                        <asp:Label ID="lbl_Ftime" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label span3">To Time</label>
                                                    <div class="controls span3">
                                                        <asp:Label ID="lbl_Ttime" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Reason</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_Reason" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="control-group" style="display: none">
                                                <label class="control-label span3">Working Hours</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_work_Hours" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Previous Comments</label>
                                                <div class=" span9">
                                                    <asp:Label ID="lbl_Comment" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="control-group" style="display: none">
                                                <label class="control-label span3">Add Comment</label>
                                                <div class="controls span3">
                                                    <asp:TextBox ID="txt_comment" runat="server" CssClass="span3" Width="220px" TextMode="MultiLine"
                                                        Height="40px"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin" style="display: none">
                                                <asp:Button ID="btn_cancel" runat="server" CssClass="btn btn-danger pull-right " Style="margin-right: 5px" OnClick="btn_cancel_Click"
                                                    Text="Cancel OD" Visible="false" />
                                                <asp:Button ID="btn_modify" runat="server" CssClass="btn btn-info pull-right " Style="margin-right: 5px" Text="Change Date" OnClick="btn_modify_Click" Visible="false" />
                                                <asp:HiddenField ID="hidd_leaveapplyid" runat="server" Visible="false" />
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Approver Hierarchy
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <asp:GridView ID="approvergrid" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive "
                                                DataKeyNames="empcode" DataSourceID="SqlDataSource2">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="33%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approver Name" HeaderStyle-Width="33%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Level" HeaderStyle-Width="34%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind ("Levels") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:HiddenField ID="hidden_leave" runat="server" Value="0" />
                                      <asp:HiddenField ID="hidd_empcode" runat="server" Value="0" />
                                            <asp:SqlDataSource ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>" runat="server" SelectCommand="select &#13;&#10;coalesce(emp_fname,'') + ' ' + coalesce(emp_m_name,'') + ' ' + coalesce(emp_l_name,'') as empname,&#13;&#10;approverid as empcode,&#13;&#10;case when eh.hr=0 then 'Level ' + cast(approverpriority as varchar(10)) else 'HR' end as levels&#13;&#10;&#13;&#10;from tbl_leave_employee_hierarchy eh &#13;&#10;inner join &#13;&#10;tbl_intranet_employee_jobDetails ed&#13;&#10;&#13;&#10;on eh.approverid=ed.empcode &#13;&#10;where eh.employeecode=@empcode&#13;&#10;order by approverpriority">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="empcode" SessionField="empcode" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <div class="clearfix"></div>
                                        </fieldset>
                                    </div>
                                </div>

                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
