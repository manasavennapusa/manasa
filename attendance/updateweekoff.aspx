<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateweekoff.aspx.cs" Inherits="attendance_updateweekoff" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />

</head>
<body>
    <form id="myForm" runat="server">
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
        <script type="text/javascript">
            function ValidateData() {
                var weekday = document.getElementById('<%=ddlWeekName.ClientID %>');
                if (weekday.value == 0) {
                    alert("Please Select Week off");
                    return false;
                }
                return true;
            }

        </script>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="page-header">
                                <div class="pull-left">
                                    <h2>Update Week Off</h2>
                                </div>
                               
                                <div class="clearfix"></div>
                            </div>

                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Week Off
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">Week Name</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddlWeekName" runat="server" Width="" OnSelectedIndexChanged="ddlWeekName_SelectedIndexChanged" AutoPostBack="true" CssClass="span3" ToolTip="Select Week Day">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Week Code </label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtWeekCode" runat="server" Width="" CssClass="span3" Enabled="false" ToolTip="Add Holiday Name" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="btn btn-info " OnClick="btnsbmit_Click" OnClientClick="return ValidateData();" ToolTip="Click here to submit the new Weekoff" /> &nbsp;
                                                <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info pull-right " ValidationGroup="nothing" Text="Reset" OnClick="btn_reset_Click" />
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




