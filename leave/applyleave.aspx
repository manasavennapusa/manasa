<%@ Page Language="C#" AutoEventWireup="true" CodeFile="applyleave.aspx.cs" Inherits="leave_applyleave" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <link href="js/StyleSheet.css" rel="stylesheet" />
    <style type="text/css">
        .star:before {
            color: red !important;
            content: " *";
        }
    </style>
</head>
<body>
    <form id="myForm" runat="server">
        <script type="text/javascript">
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
            function preventMultipleSubmissions() {
                $('#<%=btn_submit.ClientID %>').prop('disabled', true);
            }

            window.onbeforeunload = preventMultipleSubmissions;
            function ValidateLeave() {
                var reason = document.getElementById('<%=txt_reason.ClientID%>');
                var doc = document.getElementById('<%=upload_attach.ClientID%>');
                var leavename = document.getElementById('<%=dd_typeleave.ClientID%>');
                var sdate = document.getElementById('<%=txt_sdate.ClientID%>');
                var edate = document.getElementById('<%=txt_edate.ClientID%>');
                var fullday = document.getElementById('<%=rdofullday.ClientID%>');
                var halfday = document.getElementById('<%=rdohalfday.ClientID%>');

                //if (leavename.value == 0) {
                //    alert("Please select type of leave");
                //    return false;
                //}
                //if (sdate.value == "") {
                //    alert("Please select from date");
                //    return false;
                //}

                //if (edate.value == "") {
                //    alert("Please select to date");
                //    return false;

                //}
                //if (reason.value == "") {
                //    alert("Please enter reason");
                //    return false;
                //}
                //return true;

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

        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                                runat="server">
                                <ProgressTemplate>
                                    <%--<div class="modal-backdrop fade in">
                                        <div class="center">
                                            <img src="images/loader.gif" alt="" />
                                            Please Wait...
                                        </div>
                                    </div>--%>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <div class="page-header">
                                <div class="pull-left">
                                    <h2>Leave Application</h2>
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
                                                    <div style="display: none;">
                                                        <label class="control-label span3">Status</label>
                                                        <div class="span3">
                                                            <asp:Label ID="lbl_emp_status" runat="server"></asp:Label>
                                                        </div>
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
                                        <a href="#myModal" role="button" class="btn btn-primary pull-right" data-toggle="modal">Leave Status</a>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label span3">Type of Leave<span class="star"></span></label>
                                                <div class="controls span3">
                                                    <asp:DropDownList ID="dd_typeleave" runat="server" CssClass="span3" Width="220px" DataSourceID="SqlDataSource1" DataTextField="leavetype" DataValueField="leaveid" OnDataBound="dd_typeleave_DataBound" OnSelectedIndexChanged="dd_typeleave_SelectedIndexChanged" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="requiredgender" runat="server" ValidationGroup="v" ControlToValidate="dd_typeleave"
                                                        ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Please Select Type Of Leave" InitialValue="0"></asp:RequiredFieldValidator>

                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="declare @S varchar(10)
declare @St varchar(30)
set @S=(select emp_status from tbl_intranet_employee_jobDetails where empcode=@empcode)
set @St=(select maritalstatus from tbl_intranet_employee_personalDetails where empcode=@empcode)
if(@S = '3' And @St='MARRIED')
Begin
select  DISTINCT  crleave.leaveid,crleave.leavetype from tbl_leave_createleave crleave
 INNER JOIN tbl_leave_employee_leave_master elm ON elm.leaveid=crleave.leaveid INNER JOIN 
 tbl_leave_createdefaultrule r ON r.leaveid = elm.leaveid 
 where elm.empcode=@empcode and crleave.leaveid  in (1,4,5) and 
 ( applicable_to = 'A' or applicable_to = @gender ) order by crleave.leavetype
End
else if(@S = '3')
Begin
select  DISTINCT  crleave.leaveid,crleave.leavetype from tbl_leave_createleave crleave
 INNER JOIN tbl_leave_employee_leave_master elm ON elm.leaveid=crleave.leaveid INNER JOIN 
 tbl_leave_createdefaultrule r ON r.leaveid = elm.leaveid 
 where elm.empcode=@empcode and crleave.leaveid  in (1) and 
 ( applicable_to = 'A' or applicable_to = @gender ) order by crleave.leavetype
 End
else if(@S = '1')
Begin
select  DISTINCT  crleave.leaveid,crleave.leavetype from tbl_leave_createleave crleave
 INNER JOIN tbl_leave_employee_leave_master elm ON elm.leaveid=crleave.leaveid INNER JOIN 
 tbl_leave_createdefaultrule r ON r.leaveid = elm.leaveid 
 where elm.empcode=@empcode and crleave.leaveid  in (3) and 
 ( applicable_to = 'A' or applicable_to = @gender ) order by crleave.leavetype
End
 else
 begin
 select  DISTINCT  crleave.leaveid,crleave.leavetype from tbl_leave_createleave crleave
 INNER JOIN tbl_leave_employee_leave_master elm ON elm.leaveid=crleave.leaveid INNER JOIN 
 tbl_leave_createdefaultrule r ON r.leaveid = elm.leaveid 
 where elm.empcode=@empcode and crleave.leaveid not in (0) and 
 ( applicable_to = 'A' or applicable_to = @gender ) order by crleave.leavetype
 End"
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
                                                            <asp:SessionParameter Name="empcode" SessionField="empcode" />
                                                            <asp:ControlParameter ControlID="HiddenField_gender" Name="gender" PropertyName="Value"
                                                                Type="String" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
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
                                                    <label class="control-label span3">From Date<span class="star"></span></label>
                                                    <div class="controls span3">
                                                        <asp:TextBox ID="txt_sdate" runat="server" CssClass="span3" Width="220px" onkeypress="return isKey(event);" ondrop="return false;" AutoPostBack="true" OnTextChanged="txt_sdate_TextChanged" onpaste="return false;"></asp:TextBox>
                                                        <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                     
                                                        <cc1:CalendarExtender
                                                            ID="CalendarExtender1" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate" Format="dd MMM yyyy">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_sdate"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Please Enter From Date"
                                                        ValidationGroup="v" Width="16px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label span3">To Date<span class="star"></span></label>
                                                    <div class="controls span3">
                                                        <asp:TextBox ID="txt_edate" runat="server" CssClass="span2 " Width="220px" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;" AutoPostBack="true" OnTextChanged="txt_edate_TextChanged"></asp:TextBox>
                                                        <asp:Image ID="img_t" runat="server" ImageUrl="~/leave/images/clndr.gif" />

                                                        <cc1:CalendarExtender
                                                            ID="CalendarExtender2" runat="server" PopupButtonID="img_t" TargetControlID="txt_edate" Format="dd MMM yyyy">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_edate"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Please Enter To Date"
                                                        ValidationGroup="v" Width="16px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
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
                                                    <asp:Button ID="btn_calc" runat="server" Text="Calculate No. of Days" OnClick="btn_calc_Click" CssClass="btn btn-primary " OnClientClick="return Validate();" />
                                                </div>
                                            </div>
                                            <div class="widget-body">
                                                <div id="Div7" runat="server" class="example_alt_pagination">
                                                    <asp:UpdatePanel ID="diffdate" runat="server" style="margin-left: 328px">
                                                        <ContentTemplate>

                                                            <asp:GridView ID="grdpaper" runat="server" Style="width: 100px" AutoGenerateColumns="False"
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

                                                                    <asp:TemplateField HeaderText="Day Mode" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlday" runat="server" Width="120" AutoPostBack="true" CssClass="span4" Text='<%# Eval("daymode") %>'>

                                                                                <asp:ListItem Value="1">Full Day</asp:ListItem>
                                                                                <asp:ListItem Value="2">Half Day</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>


                                                                    <asp:TemplateField runat="server" Visible="false" HeaderText="Half Day Mode">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddltype" runat="server" Visible="false" Width="120" CssClass="span4" Text='<%# Eval("halfdaymode") %>'>
                                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                <asp:ListItem Value="1">First Half</asp:ListItem>
                                                                                <asp:ListItem Value="2">Second Half</asp:ListItem>
                                                                                <asp:ListItem Value="3">Half</asp:ListItem>
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
                                                <label class="control-label span3">Reason<span class="star"></span></label>
                                                <div class="controls span6">
                                                    <asp:TextBox ID="txt_reason" runat="server" CssClass="span11" TextMode="MultiLine"
                                                        onkeypress="return isalphanumericsplchar()"
                                                        Height="60px"></asp:TextBox>&nbsp;&nbsp;
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_reason"
                                                         Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Please Enter Reason"
                                                         ValidationGroup="v" Width="16px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Attachment (if any)</label>
                                                <div class="controls span3">
                                                    <asp:FileUpload ID="upload_attach" runat="server" CssClass="span3" Width="220px" />
                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="upload_attach"
                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Upload Policy"
                                                ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                    <asp:HiddenField ID="HiddenField_gender" runat="server" />
                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>
                                    <%-- <div class="widget-header">
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
                                    <div class="widget-body">
                                        <fieldset>
                                            <%--<div class="control-group">
                                                <label class="control-label span3">Reason</label>
                                                <div class="controls span6">
                                                    <asp:TextBox ID="txt_reason" runat="server" CssClass="span12" TextMode="MultiLine"
                                                        onkeypress="return isalphanumericsplchar()"
                                                        Height="60px"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Attachment (if any)</label>
                                                <div class="controls span3">
                                                    <asp:FileUpload ID="upload_attach" runat="server" CssClass="span3" Width="220px" />
                                                    <asp:HiddenField ID="HiddenField_gender" runat="server" />
                                                </div>
                                            </div>--%>
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
                                            <div class="control-group" style="display: none;">
                                                <label class="control-label span3">Add Comment</label>
                                                <div class="controls span6">
                                                    <asp:TextBox ID="txt_comment" runat="server" CssClass="span12" TextMode="MultiLine"
                                                        Height="60px"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-actions no-margin">

                                                <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-primary pull-right" Style="margin-right: 5px" Text="Reset" OnClick="btn_reset_Click" />
                                                <asp:Button ID="btn_draft" runat="server" CssClass="btn btn-primary pull-right" Style="margin-right: 5px" Text="Save Draft" OnClick="btn_draftl_Click" Visible="false" />&nbsp;
                                                <asp:Button ID="btn_submit" runat="server" CssClass="btn btn-primary pull-right " Style="margin-right: 5px" Text="Submit" OnClick="btn_submit_Click" ValidationGroup="v" />
                                                <%-- OnClientClick="return ValidateLeave();"--%>
                                                <asp:HiddenField ID="hdn_branchid" runat="server" Value="0" />
                                                <asp:HiddenField ID="prvimg" runat="server" />
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btn_submit" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                ×</button>
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

