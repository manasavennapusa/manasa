<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hrleaveupdate.aspx.cs" Inherits="leave_hrleaveupdate" %>

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
            function isKey(keyCode) {
                return false;
            }
        </script>
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
        <%-- <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
            runat="server">
            <ProgressTemplate>
                <div class="modal-backdrop fade in">
                    <div class="center">
                        <img src="images/loader.gif" alt="" />
                        Please Wait...
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
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
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Leave Apply & Updated by HR--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Pick Employee
                                </div>
                                <a data-toggle="modal" id="lslink" visible="false" runat="server" href="#myModal" class="btn btn-info pull-right pull-right" onclick="return ValidateEmpcode();">Leave Balance</a>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <div class="controls controls-row">
                                            <label class="control-label span3 ">Employee Code</label>
                                            <div class="controls span3">
                                                <asp:TextBox ID="txt_employee" runat="server" Width="220px" CssClass="span4" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            </div>
                                            <div class="controls span3">
                                                <a href="JavaScript:newPopup1('PickEmployee.aspx');" title="Pick Employee"><i class="icon-user" style="margin-top:5px"></i></a>
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
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Leave Application
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label span3">Type of Leave</label>
                                        <div class="controls span3">
                                            <asp:DropDownList ID="dd_typeleave" runat="server" CssClass="span4" OnDataBound="dd_typeleave_DataBound" OnSelectedIndexChanged="dd_typeleave_SelectedIndexChanged" AutoPostBack="True" Width="220px">
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
                                                <asp:TextBox ID="txt_sdate" runat="server" CssClass="span3" Width="220px" onkeypress="return isKey(event);" AutoPostBack="true" OnTextChanged="txt_sdate_TextChanged" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                        <cc1:CalendarExtender
                                                            ID="CalendarExtender1" runat="server" PopupButtonID="img_f"  Format="dd MMM yyyy" TargetControlID="txt_sdate">
                                                        </cc1:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label span3">To Date</label>
                                            <div class="controls span3">
                                                <asp:TextBox ID="txt_edate" runat="server" CssClass="span3 " Width="220px" onkeypress="return isKey(event);" OnTextChanged="txt_edate_TextChanged" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                <asp:Image ID="img_t" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                        <cc1:CalendarExtender
                                                            ID="CalendarExtender2" runat="server" PopupButtonID="img_t"  Format="dd MMM yyyy" TargetControlID="txt_edate">
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
                                                <asp:TextBox ID="txt_select" runat="server" CssClass="span3" Width="220px" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                <asp:Image ID="img_select" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                <cc1:CalendarExtender ID="Calendarextender3" runat="server" PopupButtonID="img_select"  Format="dd MMM yyyy" TargetControlID="txt_select">
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
                                      <div class="widget-body">
                                                                                        <div id="Div7" runat="server" class="example_alt_pagination">
                                                                                            <asp:UpdatePanel ID="diffdate" runat="server" style="margin-left:328px">
                                                                                                <ContentTemplate>

                                                                                                    <asp:GridView ID="grdpaper" runat="server" style="width:100px" AutoGenerateColumns="False"
                                                                                                        EmptyDataText="No data Found" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" OnRowDataBound="grdpaper_RowDataBound">
                                                                                                        <Columns>
                                                                                                           <%-- <asp:TemplateField HeaderText="Id">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lbintrvid" runat="server" Text='<%#Eval("dates")%>' />
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>--%>

                                                                                                            <asp:TemplateField HeaderText="Dates">
                                                                                                                <ItemTemplate>
                                                                                                                    <%--<asp:Label ID="lbldate" runat="server" dataformatstring="{0:MMMM d, yyyy}" Text='<%# Eval("dates") %>'></asp:Label>--%>
                                                                                                                 <asp:Label ID="Label1" runat="server" Text='<%# Bind("dates", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                                <%--   <EditItemTemplate>
                                                                                                      <asp:TextBox ID="txtIntervpapercode" Width="80" runat="server" Text='<%#Eval("papercode")%>' />
                                                                                                        </EditItemTemplate>--%>

                                                                                                            </asp:TemplateField>
                                                                                                            
                                                                                                           <asp:TemplateField HeaderText="Day Mode" Visible="false" >
                                                                                                                <ItemTemplate>
                                                                                                                      <asp:DropDownList ID="ddlday" runat="server" Width="120"  AutoPostBack="true"  CssClass="span4" Text='<%# Eval("daymode") %>'>
                                                                                                                       
                                                                                                                        <asp:ListItem Value="1">Full Day</asp:ListItem>
                                                                                                                        <asp:ListItem Value="2">Half Day</asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                </ItemTemplate>
                                                                                                              
                                                                                                            </asp:TemplateField>
                                                                                                       
                                                                                                        
                                                                                                            <asp:TemplateField runat="server" Visible="false"  HeaderText="Half Day Mode">
                                                                                                                <ItemTemplate>
                                                                                                                      <asp:DropDownList ID="ddltype" runat="server" Visible="false" Width="120" CssClass="span4" Text='<%# Eval("halfdaymode") %>'>
                                                                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                                                        <asp:ListItem Value="1">First Half</asp:ListItem>
                                                                                                                        <asp:ListItem Value="2">Second Half</asp:ListItem>
                                                                                                                           <asp:ListItem   Value="3">Half</asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                </ItemTemplate>
                                                                                                               
                                                                                                            </asp:TemplateField>

                                                                                                        </Columns>
                                                                                                      <%--  <Columns>
                                                                                                            <asp:CommandField ShowEditButton="true" HeaderText="Edit" ButtonType="Button" EditText="Update" UpdateText="Update" CancelText="Cancel" />
                                                                                                        </Columns>--%>

                                                                                                    </asp:GridView>
                                                                                                </ContentTemplate>
                                                                                            </asp:UpdatePanel>
                                                                                            <div class="clearfix"></div>
                                                                                        </div>
                                                                                    </div>

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
                                            <asp:HiddenField ID="hidden_leave" runat="server" Value="0" />
                                        </div>
                                    </div>

                                     <div class="control-group">
                                        <label class="control-label span3">Add Comment</label>
                                        <div class="controls span3">
                                            <asp:TextBox ID="txt_comment" runat="server" CssClass="span3" Width="220px" TextMode="MultiLine"
                                                Height="40px"></asp:TextBox>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>

                           <%--<div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Leave Adjustment
                                </div>
                            </div>--%>

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

                           <%-- <div class="widget-body">
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
                                            <asp:HiddenField ID="hidden_leave" runat="server" Value="0" />
                                        </div>
                                    </div>
                                </fieldset>
                            </div>--%>

                            <div class="widget-body">
                                <fieldset>

                                   <%-- <div class="control-group">
                                        <label class="control-label span3">Add Comment</label>
                                        <div class="controls span3">
                                            <asp:TextBox ID="txt_comment" runat="server" CssClass="span3" Width="220px" TextMode="MultiLine"
                                                Height="40px"></asp:TextBox>
                                        </div>
                                    </div>--%>

                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info pull-right " Text="Reset" Style="margin-right: 15px" OnClick="btn_reset_Click" />
                                        <asp:Button ID="btn_submit" runat="server" CssClass="btn btn-info pull-right " Style="margin-right: 15px" Text="Submit" OnClick="btn_submit_Click" OnClientClick="return ValidateLeave();" />&nbsp;&nbsp;
                                        
                                        <asp:Button ID="btn_draft" runat="server" CssClass="btn btn-info pull-right " Text="Save Draft" OnClick="btn_draftl_Click" Visible="false" />&nbsp;
                                            <asp:HiddenField ID="hdn_branchid" runat="server" Value="0" />
                                        <asp:HiddenField ID="prvimg" runat="server" />
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <%--  </ContentTemplate>
                    </asp:UpdatePanel>--%>
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


