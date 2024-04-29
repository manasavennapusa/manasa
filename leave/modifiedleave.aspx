<%@ Page Language="C#" AutoEventWireup="true" CodeFile="modifiedleave.aspx.cs" Inherits="leave_modifiedleave" %>

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
            function Validate() {
                var sdate = document.getElementById('<%=txt_sdate.ClientID%>');
                var edate = document.getElementById('<%=txt_edate.ClientID%>');
                var fullday = document.getElementById('<%=rdofullday.ClientID%>');
                var halfday = document.getElementById('<%=rdohalfday.ClientID%>');

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
                var reason = document.getElementById('<%=txt_reason.ClientID%>');
                var doc = document.getElementById('<%=upload_attach.ClientID%>');

                var sdate = document.getElementById('<%=txt_sdate.ClientID%>');
                var edate = document.getElementById('<%=txt_edate.ClientID%>');
                var fullday = document.getElementById('<%=rdofullday.ClientID%>');
                var halfday = document.getElementById('<%=rdohalfday.ClientID%>');


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
                return true;

            }

            function setImage(btnID) {
                var btn = document.getElementById(btnID);
                btn.style.background = 'url(12501270608.gif)';
            }


        </script>
        <script type="text/javascript">
            function isKey(keyCode) {
                return false;
            }
        </script>
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
                                    <h2>Modified Leave </h2>
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
                                        <a href="#myModal" role="button" class="btn btn-info pull-right pull-right" data-toggle="modal">Leave Status</a>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label span3">Type of Leave</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_leave" runat="server"></asp:Label>
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
                                                        <asp:TextBox ID="txt_sdate" runat="server" CssClass="span3" Width="220px" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                        <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                        <cc1:CalendarExtender
                                                            ID="CalendarExtender1" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label span3">To Date</label>
                                                    <div class="controls span3">
                                                        <asp:TextBox ID="txt_edate" runat="server" CssClass="span3" Width="220px" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
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
                                                        <asp:TextBox ID="txt_select" runat="server" CssClass="span3 " Width="220px" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                        <asp:Image ID="img_select" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                        <cc1:CalendarExtender ID="Calendarextender3" runat="server" PopupButtonID="img_select" TargetControlID="txt_select">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">No. of Days</label>
                                                <div class="controls span2">
                                                    <asp:TextBox ID="txt_nod" runat="server" CssClass="span3" Width="220px" Enabled="False">0</asp:TextBox>
                                                </div>
                                                <div class="controls span2">
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
                                                <div class="controls span6">
                                                    <asp:TextBox ID="txt_reason" runat="server" CssClass="span12" Width="" TextMode="MultiLine" Rows="5" Columns="5"
                                                        onkeypress="return isalphanumericsplchar()"
                                                        Height="60px"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Attachment (if any)</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_file" runat="server"></asp:Label><br />
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
                                                DataKeyNames="empcode">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approver Name" HeaderStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Level" HeaderStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("Levels") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="35%">
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

                                            </asp:GridView>
                                            <asp:HiddenField ID="hidden_leave" runat="server" Value="0" />

                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label span3">Previous Comment</label>
                                                <div class="controls span9">
                                                    <asp:Label ID="lbl_comments" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Add Comment</label>
                                                <div class="controls span6">
                                                    <asp:TextBox ID="txt_comment" runat="server" CssClass="span12" Width="" TextMode="MultiLine"
                                                        Height="60px"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btn_submit" runat="server" CssClass="btn btn-info pull-right " Style="margin-right: 5px" Text="Update Leave" OnClick="btn_submit_Click" OnClientClick="return ValidateLeave();" />&nbsp;&nbsp;
                                                <asp:Button ID="txt_cancel" runat="server" CssClass="btn btn-info pull-right " Style="margin-right: 5px; display: none" Text="Cancel leave" OnClick="btn_cancel_Click" />&nbsp;&nbsp;
                                                <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info pull-right " Style="margin-right: 5px" Text="Reset" OnClick="btn_reset_Click" />&nbsp;
                                                <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                                                <asp:HiddenField ID="hidd_leaveapplyid" runat="server" Value="0" />
                                                <asp:HiddenField ID="hidd_leaveid" runat="server" />
                                                <asp:HiddenField ID="prvimg" runat="server" />
                                                <asp:HiddenField ID="hidd_leave_status" runat="server" />
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


