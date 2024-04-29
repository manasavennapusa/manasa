<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateemployeeleaveprofile.aspx.cs" Inherits="leave_updateemployeeleaveprofile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <%--<script type="text/javascript">
        function ValidateLeaveProfile() {
            var hrcode = document.getElementById('<%=txt_hr.ClientID%>');

            if (hrcode.value == "") {
                alert("Please select HR");
                return false;
            }
            return true;
        }
        function ValidateApprover() {
            var aprcode = document.getElementById('<%=txt_approver.ClientID%>');
            if (aprcode.value == "") {
                alert("Please select approver");
                return false;
            }
            return true;
        }
        function ValidateLeavaePolicy() {
            var lpolicy = document.getElementById('<%=drp_policy.ClientID%>');
            if (lpolicy.value == 0) {
                alert("Please select leave policy");
                return false;
            }
            return true;
        }
        function isKey(keyCode) {

            return false;

        }
    </script>--%>
    <script src="Js/popup.js"></script>
       <style type="text/css">
        .star:before
        {
            color: red !important;
            content: " *";
        }
    </style>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Employee Leave Profile</h2>
                            </div>
                         
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Leave Profile--%>
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Edit
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label span3">Employee Code</label>
                                            <div class="controls span3">
                                                <asp:Label ID="lbl_empcode" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid" style="display:none">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Add Approver
                                    </div>
                                    <asp:Button ID="btn_resetgrid" runat="server" CssClass="btn btn-info pull-right " ValidationGroup="onone"
                                        Text="Reset Grid" OnClick="btn_greset_Click" />
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label span3">Approver Name</label>
                                            <div class="controls span2">
                                                <asp:TextBox ID="txt_approver" runat="server" CssClass="span3" Width="220px" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                            </div>
                                            <div class="controls span3">
                                                <a href="JavaScript:newPopup1('PickApprover.aspx');" class="link05"><i class="icon-user"></i>Pick Approver</a>
                                                <asp:Button ID="btn_add" runat="server" CssClass="btn btn-info pull-right " Text="Add" OnClick="btn_add_Click"
                                                    OnClientClick="return ValidateApprover();" />
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="approvalgrid" runat="server"
                                            AutoGenerateColumns="False"
                                            CssClass="table table-striped table-bordered table-hover table-checkable table-responsive " OnPreRender="approvalgrid_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Emp Code" HeaderStyle-Width="24%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Approver Name" HeaderStyle-Width="24%" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Level" HeaderStyle-Width="24%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("level") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle Height="5px" />
                                        </asp:GridView>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid" style="display:none">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>HR
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label span3">HR</label>
                                            <div class="controls span2">
                                                <asp:TextBox ID="txt_hr" runat="server" CssClass="span3" Width="220px" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            </div>
                                            <div class="controls span3"><a href="JavaScript:newPopup1('PickHR.aspx');" class="link05"><i class="icon-user"></i>Pick HR</a></div>
                                        </div>
                                        <div class="control-group" style="display: none">
                                            <label class="control-label span3">Pro Rata Applicable </label>
                                            <div class="controls span3">
                                                <asp:RadioButton ID="opt_prorata_yes" runat="server" GroupName="kb" Text="Yes" />
                                                <asp:RadioButton ID="opt_prorata_no" runat="server" GroupName="kb" Text="No" Checked="True" />
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
                                        <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Set Leave Rule--%>
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Set Policy
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label span3">Leave Policy<span class="star"></span></label>
                                            <div class="controls span3">
                                                <asp:DropDownList ID="drp_policy" runat="server" CssClass="span3" Width="220px" OnDataBound="drp_policy_DataBound" Enabled="false">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="v" ControlToValidate="drp_policy"
                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Please Select Leave Policy" InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="controls span1" style="display:none">
                                                <asp:Button ID="btn_policy" runat="server" CssClass="btn btn-info pull-right " OnClick="btn_policy_Click"
                                                    Text="Set Policy" OnClientClick="return ValidateLeavaePolicy();" />
                                            </div>
                                        </div>

                                    </fieldset>
                                </div>
                                <div class="widget-body">
                                    <div id="Div1" class="example_alt_pagination">
                                        <asp:GridView ID="grid_customizerule" runat="server"
                                            CssClass="table table-striped table-bordered table-hover table-checkable table-responsive"
                                            AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField Visible="False" HeaderStyle-Width="0%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("policyid") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("leaveid") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Leave Policy" HeaderStyle-Width="40%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("policyname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Leave Type" HeaderStyle-Width="30%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind ("leavetype") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Entitled Days" HeaderStyle-Width="30%">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_entdays" Text='<%# Bind("entitled_days")%>' CssClass="span3" Width="220px"
                                                            runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle Height="5px" />
                                        </asp:GridView>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions no-margin">
                            <asp:Button ID="btn_submit" runat="server" CssClass="btn btn-info  " OnClick="btn_submit_Click" Text="Update" />&nbsp;&nbsp;
                            <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info " OnClick="btn_reset_Click" Text="Cancel" />
                            <asp:HiddenField ID="hidd_name" runat="server" />
                            <asp:HiddenField ID="hiddenlevel" runat="server" Value="1" />
                            <asp:HiddenField ID="hidden_hr" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>

