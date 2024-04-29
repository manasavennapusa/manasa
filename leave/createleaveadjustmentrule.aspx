<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createleaveadjustmentrule.aspx.cs" Inherits="leave_createleaveadjustmentrule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script type="text/javascript">
        function ValidateLeave()
        {
            var lpolicy = document.getElementById('<%=dd_policy.ClientID%>');
            var leave = document.getElementById('<%=drp_leave.ClientID%>');
            if (lpolicy.value == 0) {
                alert("Please select leave policy");
                return false;

            }
            if (leave.value == 0) {
                alert("Please select leave type");
                return false;

            }
            var ladjleave = document.getElementById('<%=drp_aleave.ClientID%>');
            if (ladjleave.value == 0) {
                alert("Please select adjust leave type");
                return false;

            }


            return true;
        }
        function ValidateAdjustLeave() {
            var ladjleave = document.getElementById('<%=drp_aleave.ClientID%>');
            if (ladjleave.value == 0) {
                alert("Please select adjust leave type");
                return false;

            }

            return true;
        }
    </script>

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
                                <h2>Leave Adjustment Rule</h2>
                            </div>
                           
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Create Adjustment Leave Rule--%>
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Create
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label span3">Policy Name<span class="star"></span></label>
                                            <div class="controls span3">
                                                <asp:DropDownList ID="dd_policy" runat="server" CssClass="span3"   OnDataBound="dd_policy_DataBound" Width="220px">
                                                </asp:DropDownList>
                                                 <asp:RequiredFieldValidator ID="requiredgender" runat="server" ValidationGroup="v" ControlToValidate="dd_policy"
                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Please Select Policy Name" InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label span3">Leave Name<span class="star"></span></label>
                                            <div class="controls span3">
                                                <asp:DropDownList ID="drp_leave" runat="server" CssClass="span3"  Width="220px" OnDataBound="drp_leave_DataBound" >
                                                </asp:DropDownList>
                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="v" ControlToValidate="drp_leave"
                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Please Select Leave Name" InitialValue="0"></asp:RequiredFieldValidator>
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
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Adjustment Leave
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label span3">Adjustment Leave<span class="star"></span></label>
                                            <div class="controls span2">
                                                <asp:DropDownList ID="drp_aleave" runat="server" CssClass="span3"  Width="220px" OnDataBound="drp_aleave_DataBound" >
                                                </asp:DropDownList>                                    
                                            </div>&nbsp;&nbsp;
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="v" ControlToValidate="drp_aleave"
                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Please Select Adjustment Leave" InitialValue="0"></asp:RequiredFieldValidator>
                                            <div class="span2">
                                                <asp:Button ID="btm_add" runat="server" Text="Add" CssClass="btn btn-info pull-right " OnClick="btm_add_Click" OnClientClick="return ValidateLeave();" />
                                            </div>
                                        </div>

                                    </fieldset>
                                </div>
                            </div>
                        </div>
                        <div class="widget-body">
                            <div id="dt_example" class="example_alt_pagination">
                                <asp:GridView ID="grid_aleave" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="aleaveid" OnPreRender="grid_aleave_PreRender" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive "
                                    OnRowDeleting="grid_aleave_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Leave Name" HeaderStyle-Width="25%">
                                            <ItemTemplate>
                                                <asp:Label ID="l3" runat="server" Text='<%# Bind("aleavename")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete" CssClass="link05"
                                                    OnClientClick="return confirm(' Do you want to Delete this record?');"><i class="icon-remove"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                        <div class="form-actions no-margin">
                            <asp:Button ID="btn_submit" runat="server" CssClass="btn btn-info " Text="Submit" OnClick="btn_submit_Click" ValidationGroup="v" />&nbsp;
                                <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info  " ValidationGroup="nothing" Text="Reset" OnClick="btn_reset_Click" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
