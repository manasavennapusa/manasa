<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createleave.aspx.cs" Inherits="leave_createleave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
   <%-- <script type="text/javascript">
        function ValidateDate() {
            var leavename = document.getElementById('<%=txt_leave_type.ClientID %>');
             var displayname = document.getElementById('<%=txt_display_name.ClientID %>');
             if (leavename.value == "") {
                 alert("Please enter leave name");
                 return false;
             }
             if (displayname.value == "") {
                 alert("Please enter display name");
                 return false;
             }
             return true;
         }
    </script>--%>
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
                                <%--<h2>Create Leave</h2>--%>
                                <h2>Leave Master</h2>
                            </div>
                           
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Create
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label">Leave Name<span class="star"></span></label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_leave_type" CssClass="span4" runat="server" AutoCompleteType="Disabled" ToolTip="Leave Name"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_leave_type"
                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Leave Name"
                                                ValidationGroup="v" Width="16px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">Display Name<span class="star"></span></label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_display_name" runat="server" CssClass="span4" ToolTip="Display name of leave"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_display_name"
                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Display Name"
                                                ValidationGroup="v" Width="16px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label" style="margin-left:0px">Description</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_description" runat="server" TextMode="MultiLine" ToolTip="Description of Leave" CssClass="span4"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-actions no-margin">
                                            <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="btn btn-info " OnClick="btnsbmit_Click" ValidationGroup="v" />&nbsp;&nbsp;
                                            <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info " Text="Reset" OnClick="btn_reset_Click" />
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
