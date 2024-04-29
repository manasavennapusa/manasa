<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hrupdateleaveforapproval.aspx.cs" Inherits="leave_hrupdateleaveforapproval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        <script type="text/javascript">

            function ValidateEmpcode() {
                var empcode = document.getElementById('<%=txt_employee.ClientID%>');
                if (empcode.value == "") {
                    alert("Please select empcode");
                    return false;
                }
            }
            function Validate() {

                var leavename = document.getElementById('<%=dd_typeleave.ClientID%>');
                var sdate = document.getElementById('<%=txt_sdate.ClientID%>');
                var edate = document.getElementById('<%=txt_edate.ClientID%>');
                var fullday = document.getElementById('<%=rdofullday.ClientID%>');
                var halfday = document.getElementById('<%=rdohalfday.ClientID%>');

                if (leavename.value == 0) {
                    alert("Please select type of leave");
                    return false;
                }
                if (sdate.value == "") {
                    alert("Please select from date");
                    return false;
                }

                if (edate.value == "") {
                    alert("Please select to date");
                    return false;

                }
                return true;
            }
            function ValidateLeave() {
                var empcode = document.getElementById('<%=txt_employee.ClientID%>');
                var reason = document.getElementById('<%=txt_reason.ClientID%>');
                var doc = document.getElementById('<%=upload_attach.ClientID%>');
                var leavename = document.getElementById('<%=dd_typeleave.ClientID%>');
                var sdate = document.getElementById('<%=txt_sdate.ClientID%>');
                var edate = document.getElementById('<%=txt_edate.ClientID%>');
                var fullday = document.getElementById('<%=rdofullday.ClientID%>');
                var halfday = document.getElementById('<%=rdohalfday.ClientID%>');

                if (empcode.value == 0) {
                    alert("Please select empcode");
                    return false;
                }

                if (leavename.value == 0) {
                    alert("Please select type of leave");
                    return false;
                }
                if (sdate.value == "") {
                    alert("Please select from date");
                    return false;
                }

                if (edate.value == "") {
                    alert("Please select to date");
                    return false;

                }
                if (reason.value == "") {
                    alert("Please enter reason");
                    return false;
                }
                return true;

            }
            function disableBtn(btnID, newText) {

                var btn = document.getElementById(btnID);
                setTimeout("setImage('" + btnID + "')", 60000);
                btn.disabled = true;
                btn.value = newText;
            }

            function setImage(btnID) {
                var btn = document.getElementById(btnID);
                btn.style.background = 'url(12501270608.gif)';
            }
            function isKey(keyCode) {
                return false;
            }
        </script>
        <script src="Js/popup.js"></script>
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
                                    <h2>Leave Apply & Update by HR </h2>
                                </div>
                               
                                <div class="clearfix"></div>
                            </div>
                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Leave Apply & Updated by HR
                                             <a data-toggle="modal" id="lslink" visible="false" runat="server" href="#myModal" class="btn btn-info pull-right pull-right" onclick="return ValidateEmpcode();">Leave Status</a>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <div class="controls controls-row">
                                                    <label class="control-label span3 ">Employee Code/Name</label>
                                                    <div class="controls span4">
                                                        <asp:TextBox ID="txt_employee" runat="server" Width="220px" CssClass="span4" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                    </div>
                                                    <div class="controls span3">
                                                        <a href="JavaScript:newPopup1('PickEmployee.aspx');"><i class="icon-user"></i>Pick Employee</a>
                                                    </div>
                                                    <div class="controls span1">
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info pull-right " Text="Get Leaves" OnClick="btnSubmit_Click" OnClientClick="return ValidateEmpcode();" />
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
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Apply Leave
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label span3">Type of Leave</label>
                                                <div class="controls span3">
                                                    <asp:DropDownList ID="dd_typeleave" runat="server" CssClass="span4" OnDataBound="dd_typeleave_DataBound" OnSelectedIndexChanged="dd_typeleave_SelectedIndexChanged" AutoPostBack="True" Width="">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="control-group" id="div" visible="false" runat="server">
                                                <label class="control-label span3">Leave Mode</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rdofullday" runat="server" Checked="True" GroupName="days" OnCheckedChanged="rdofullday_CheckedChanged" Text="Full Day" ValidationGroup="noone" AutoPostBack="True" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rdohalfday" runat="server" GroupName="days" OnCheckedChanged="rdohalfday_CheckedChanged" Text="Half Day" ValidationGroup="noone" AutoPostBack="True" />
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="control-group" id="div_Furnelleave" visible="false" runat="server">
                                                <label class="control-label span3">Relation</label>
                                                <div class="controls span3">
                                                    <asp:DropDownList ID="ddl_relation" CssClass="span3" Width="220px" runat="server">
                                                        <asp:ListItem Value="0">--Select Relation --</asp:ListItem>
                                                        <asp:ListItem>Spouse</asp:ListItem>
                                                        <asp:ListItem>Parents</asp:ListItem>
                                                        <asp:ListItem>Siblings</asp:ListItem>
                                                        <asp:ListItem>Children</asp:ListItem>
                                                        <asp:ListItem>Father-in-law</asp:ListItem>
                                                        <asp:ListItem>Mother-in-law</asp:ListItem>
                                                        <asp:ListItem>Son-in-law</asp:ListItem>
                                                        <asp:ListItem>Daughter-in-law</asp:ListItem>
                                                        <asp:ListItem>Grandchild</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div id="divfull" visible="true" runat="server">
                                                <div class="control-group">
                                                    <label class="control-label span3">From Date</label>
                                                    <div class="controls span3">
                                                        <asp:TextBox ID="txt_sdate" runat="server" CssClass="span3" Width="220px"></asp:TextBox>
                                                        <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                        <cc1:CalendarExtender
                                                            ID="CalendarExtender1" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label span3">To Date</label>
                                                    <div class="controls span3">
                                                        <asp:TextBox ID="txt_edate" runat="server" CssClass="span3 " Width="220px"></asp:TextBox>
                                                        <asp:Image ID="img_t" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                        <cc1:CalendarExtender
                                                            ID="CalendarExtender2" runat="server" PopupButtonID="img_t" TargetControlID="txt_edate">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="divhalf" visible="false" runat="server">
                                                <div class="control-group">
                                                    <label class="control-label span3">Half Day Mode</label>
                                                    <div class="controls span3">
                                                        <label class="radio inline">
                                                            <asp:RadioButton ID="opt_first" runat="server" Checked="True" GroupName="b" Text="First Half" OnCheckedChanged="opt_first_CheckedChanged" />
                                                        </label>
                                                        <label class="radio inline">
                                                            <asp:RadioButton ID="opt_second" runat="server" GroupName="b" Text="Second Half" OnCheckedChanged="opt_second_CheckedChanged" />
                                                        </label>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label span3">Select Date</label>
                                                    <div class="controls span3">
                                                        <asp:TextBox ID="txt_select" runat="server" CssClass="span3" Width="220px"></asp:TextBox>
                                                        <asp:Image ID="img_select" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                        <cc1:CalendarExtender ID="Calendarextender3" runat="server" PopupButtonID="img_select" TargetControlID="txt_select">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">No. of Days</label>
                                                <div class="controls span3">
                                                    <asp:TextBox ID="txt_nod" runat="server" CssClass="span3" Width="220px" Enabled="False">0</asp:TextBox>
                                                </div>
                                                <div class="controls span3">
                                                    <asp:Button ID="btn_calc" runat="server" Text="Calculate No. of Days" OnClick="btn_calc_Click" CssClass="btn btn-info pull-right " OnClientClick="return Validate();" />
                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Leave Adjustment
                                        </div>
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
                                                    <asp:TextBox ID="txt_reason" runat="server" CssClass="span3" Width="220px" TextMode="MultiLine" Rows="5" Columns="5"
                                                        onkeypress="return isalphanumericsplchar()"
                                                        Height="40px"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Attachment (if any)</label>
                                                <div class="controls span3">
                                                    <asp:FileUpload ID="upload_attach" runat="server" CssClass="span3" Width="220px" />
                                                    <asp:HiddenField ID="HiddenField_gender" runat="server" />
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
                                            <asp:GridView ID="approvergrid" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive " OnPreRender="approvergrid_PreRender"
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
                                            <asp:SqlDataSource ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>" runat="server" SelectCommand="select &#13;&#10;coalesce(emp_fname,'') + ' ' + coalesce(emp_m_name,'') + ' ' + coalesce(emp_l_name,'') as empname,&#13;&#10;approverid as empcode,&#13;&#10;case when eh.hr=0 then 'Level ' + cast(approverpriority as varchar(10)) else 'HR' end as levels&#13;&#10;&#13;&#10;from tbl_leave_employee_hierarchy eh &#13;&#10;inner join &#13;&#10;tbl_intranet_employee_jobDetails ed&#13;&#10;&#13;&#10;on eh.approverid=ed.empcode &#13;&#10;where eh.employeecode=@empcode&#13;&#10;order by approverpriority">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="empcode" SessionField="empcode" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label span3">Add Comment</label>
                                                <div class="controls span3">
                                                    <asp:TextBox ID="txt_comment" runat="server" CssClass="span3" Width="220px" TextMode="MultiLine"
                                                        Height="40px"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btn_submit" runat="server" CssClass="btn btn-info pull-right " Text="Submit" OnClick="btn_submit_Click" OnClientClick="return ValidateLeave();" />
                                                <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info pull-right " Text="Reset" OnClick="btn_reset_Click" />
                                                <asp:Button ID="btn_draft" runat="server" CssClass="btn btn-info pull-right " Text="Save Draft" OnClick="btn_draftl_Click" Visible="false" />&nbsp;
                                            <asp:HiddenField ID="hdn_branchid" runat="server" Value="0" />
                                                <asp:HiddenField ID="prvimg" runat="server" />
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
                            <h4 id="myModalLabel">Leave Balance
                            </h4>
                        </div>
                        <div class="modal-body">
                            <iframe src="MyLeaveBalance.aspx" width="100%" frameborder="0" scrolling="yes" height="300px"></iframe>
                            <asp:HiddenField ID="hdnempcode" runat="server" />
                            <asp:HiddenField ID="hdnGender" runat="server" />
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


