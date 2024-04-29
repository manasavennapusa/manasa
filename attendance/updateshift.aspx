<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateshift.aspx.cs" Inherits="attendance_updateshift" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script src="js/popup.js"></script>
    <script src="js/timepicker.js"></script>
    <script type="text/javascript">
        function ValidateData() {
            var shiftname = document.getElementById('<%=txtshift.ClientID %>');
            var branch = document.getElementById('<%=ddbranch_id.ClientID %>');
            var fromtime = document.getElementById('<%=txtstime.ClientID %>');
            var totime = document.getElementById('<%=txtetime.ClientID %>');
            if (branch.value == 0) {
                alert("Please Select Branch");
                return false;
            }

            if (shiftname.value == "") {
                alert("Please Enter Shift Name");
                return false;
            }
            if (fromtime.value == "") {
                alert("Please Enter Shift Start Time");
                return false;
            }
            if (totime.value == "") {
                alert("Please Enter Shift End Time");
                return false;
            }
            return true;
        }
    </script>
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
                                    <h2>Update Shift</h2>
                                </div>
                                
                                <div class="clearfix"></div>
                            </div>

                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Update Shift
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">Shift Name</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtshift" runat="server" CssClass="blue1" onkeypress="return isalphanumericsplchar()"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Work Location</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddbranch_id" runat="server" CssClass="blue1" DataSourceID="SqlDataSource1"
                                                        DataTextField="branch_name" DataValueField="branch_id" Width="">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        DeleteCommand="DELETE FROM [tbl_intranet_branch_detail] WHERE [branch_id] = @branch_id"
                                                        InsertCommand="INSERT INTO [tbl_intranet_branch_detail] ([branch_id], [branch_name]) VALUES (@branch_id, @branch_name)"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]"
                                                        UpdateCommand="UPDATE [tbl_intranet_branch_detail] SET [branch_name] = @branch_name WHERE [branch_id] = @branch_id">
                                                        <DeleteParameters>
                                                            <asp:Parameter Name="branch_id" Type="Int32" />
                                                        </DeleteParameters>
                                                        <UpdateParameters>
                                                            <asp:Parameter Name="branch_name" Type="String" />
                                                            <asp:Parameter Name="branch_id" Type="Int32" />
                                                        </UpdateParameters>
                                                        <InsertParameters>
                                                            <asp:Parameter Name="branch_id" Type="Int32" />
                                                            <asp:Parameter Name="branch_name" Type="String" />
                                                        </InsertParameters>
                                                    </asp:SqlDataSource>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Start Time</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtstime" runat="server" CssClass="blue1" Enabled="False"></asp:TextBox>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">End Time</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtetime" runat="server" CssClass="blue1" Enabled="False"></asp:TextBox>
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Shift Description</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtshiftDesc" runat="server" CssClass="blue1" Width="" onkeypress="return isalphanumericsplchar()" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="Button3" runat="server" Text="Submit" CssClass="btn btn-info pull-right " OnClick="btnsubmit_Click" OnClientClick="return ValidateData()" ToolTip="Click to submit the created leave" />
                                            </div>
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


