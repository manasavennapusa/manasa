<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgetpassword.aspx.cs" Inherits="forgetpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="icomoon/style.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" />
    <script type="text/javascript">
        function ValidateDate() {
            var empcode = document.getElementById("empcode");
            var emailid = document.getElementById("email");
            if (empcode.value == "") {
                alert("Please enter Empployee Code");
                return false;
            }
            if (emailid.value == "") {
                alert("Please enter Email Id.");
                return false;
            }
            return true;
        }

    </script>
    <style>
        .center
        {
            position: absolute;
            top: 448px;
            left: 500px;
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
                        <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                            runat="server">
                            <ProgressTemplate>
                                <div class="modal-backdrop fade in">
                                    <div>
                                     <%--   <img src="../img/loading.gif" alt=""/>--%>
                                        <asp:Image ID="imag1" runat="server" ImageUrl="~/img/loading.gif" Style="text-align:inherit"/>
                                    Please Wait...
                                    </div>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Reset Password</h2>
                            </div>
                            <div class="pull-right">
                                <ul class="stats">
                                    <%--<li class="color-first">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe0b3;"></span>
                                        <div class="details">
                                            <span class="big">12</span>
                                            <span>New Tasks</span>
                                        </div>
                                    </li>--%>
                                   <%-- <li class="color-second hidden-phone">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe052;"></span>
                                        <div class="details" id="date-time">
                                            <span>Date </span>
                                            <span>Day, Time</span>
                                        </div>
                                    </li>--%>
                                </ul>
                            </div>
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        Reset Password
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label">Employee Code</label>
                                            <div class="controls">
                                                <input type="text" id="empcode" name="empcode" class="form-control" placeholder="Enter Employee Code" data-rule-required="true" data-rule-email="true" data-msg-required="Please enter your employee code." runat="server" />
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">Official Email Id</label>
                                            <div class="controls">
                                                <input type="text" id="email" name="email" class="form-control" placeholder="Enter Email Id" data-rule-required="true" data-rule-email="true" data-msg-required="Please enter your email." runat="server" />
                                            </div>
                                        </div>

                                        <div class="form-actions no-margin">
                                            <asp:Button ID="Reset" CssClass="btn btn-info" Text="Reset" runat="server" OnClick="Reset_Click" />
                                            <asp:HiddenField ID="hdnpassword" runat="server" />
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

