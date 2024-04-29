<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateattendancerule.aspx.cs" Inherits="attendance_updateattendancerule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script type="text/javascript">
        function ValidateData() {

            var shift = document.getElementById('<%=dd_shift.ClientID %>');
            var earlyin = document.getElementById('<%=txt_early_in_time.ClientID %>');
            var lateiin = document.getElementById('<%=txt_latein_time.ClientID %>');
            var earlyout = document.getElementById('<%=txt_earlyout_time.ClientID %>');
            var lateiout = document.getElementById('<%=txt_lateout_time.ClientID %>');

            if (shift.value == 0) {
                alert("Please Select Shift");
                return false;
            }

            if ((IsEmpty(earlyin))) {
                alert("Please Enter Early In Time");
                return false;
            }
            if ((IsEmpty(lateiin))) {
                alert("Please Enter Late In Time");
                return false;
            }
            if ((IsEmpty(earlyout))) {
                alert("Please Enter Early Out Time");
                return false;
            }
            if ((IsEmpty(lateiout))) {
                alert("Please Enter Late Out Time");
                return false;
            }

            if (!(/^([0]?[0-9]|[1][0-2]|[2][0-3]):([0-5][0-9]|[1-9]):([0-5][0-9]|[1-9])$/.test(earlyin.value))) {
                alert("Please enter Valid Early In Time Formate like 00:00:00");
                return false;
            }
            if (!(/^([0]?[0-9]|[1][0-2]|[2][0-3]):([0-5][0-9]|[1-9]):([0-5][0-9]|[1-9])$/.test(lateiin.value))) {
                alert("Please enter Valid Late In Time Formate like 00:00:00");
                return false;
            }
            if (!(/^([0]?[0-9]|[1][0-2]|[2][0-3]):([0-5][0-9]|[1-9]):([0-5][0-9]|[1-9])$/.test(earlyout.value))) {
                alert("Please enter Valid Early Out  Time Formate like 00:00:00");
                return false;
            }
            if (!(/^([0]?[0-9]|[1][0-2]|[2][0-3]):([0-5][0-9]|[1-9]):([0-5][0-9]|[1-9])$/.test(lateiout.value))) {
                alert("Please enter Valid Late Out Time Formate like 00:00:00");
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
                                    <h2>Update Attendance Rule</h2>
                                </div>
                               
                                <div class="clearfix"></div>
                            </div>

                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Attendance Rule
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">Select Shift</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="dd_shift" runat="server" CssClass="span3">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Early In Time</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_early_in_time" runat="server" CssClass="span3" Width="">00:00:00</asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Late in Time</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_latein_time" runat="server" CssClass="span3" Width="">00:00:00</asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Early out</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_earlyout_time" runat="server" CssClass="span3" Width="">00:00:00</asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Late out</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_lateout_time" runat="server" CssClass="span3">00:00:00</asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btnsbmit" runat="server" CssClass="btn btn-info" Text="Update" OnClientClick="return ValidateData();" OnClick="btnsbmit_Click" />
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


