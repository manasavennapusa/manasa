<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hrodapplyupdate.aspx.cs" Inherits="leave_hrodapplyupdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <link href="js/StyleSheet.css" rel="stylesheet" />
    <script src="js/popup.js"></script>
    <script src="js/timepicker.js"></script>
</head>
<body>
    <form id="myForm" runat="server">
        <script type="text/javascript">
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

            function ValidateOD() {
                var reason = document.getElementById('<%=txt_reason.ClientID%>');
                var sdate = document.getElementById('<%=txt_sdate.ClientID%>');
                var ftime = document.getElementById('<%=txt_edate.ClientID%>');
                var ttime = document.getElementById('<%=txt_sdate.ClientID%>');
                var edate = document.getElementById('<%=txt_edate.ClientID%>');
                var fullday = document.getElementById('<%=rdofullday.ClientID%>');
                var halfday = document.getElementById('<%=rdohalfday.ClientID%>');
                var date = document.getElementById('<%=txt_select.ClientID%>');

                if (sdate.value == "") {
                    alert("Please select from date");
                    return false;
                }

                if (edate.value == "") {
                    alert("Please select to date");
                    return false;

                }
                if (ftime.value == "") {
                    alert("Please select from time");
                    return false;
                }

                if (ttime.value == "") {
                    alert("Please select to time");
                    return false;

                }
                if (reason.value == "") {
                    alert("Please enter reason");
                    return false;
                }
                return true;

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
                                    <h2>OD Apply & Updated By HR </h2>
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
                                                    <label class="control-label span3 ">Employee Code/Name</label>
                                                    <div class="controls span4">
                                                        <asp:TextBox ID="txt_employee" runat="server" Width="220px" CssClass="span4" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                    </div>
                                                    <div class="controls span2">
                                                        <a href="JavaScript:newPopup1('PickEmployee.aspx');"><i class="icon-user"></i>Pick Employee</a>
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
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>OD Application
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group" style="display: none">
                                                <label class="control-label span3">OD Type</label>
                                                <div class="controls span3">
                                                    <asp:DropDownList ID="ddlOdType" runat="server" CssClass="span3" Width="220px"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">OD Mode</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rdofullday" runat="server" Checked="True" GroupName="days" OnCheckedChanged="rdofullday_CheckedChanged" Text="Full Day" ValidationGroup="noone" AutoPostBack="True" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rdohalfday" runat="server" GroupName="days" OnCheckedChanged="rdohalfday_CheckedChanged" Text="Half Day" ValidationGroup="noone" AutoPostBack="True" />
                                                    </label>
                                                </div>
                                            </div>
                                            <div id="divfull" visible="true" runat="server">
                                                <div class="control-group">
                                                    <label class="control-label span3">From Date</label>
                                                    <div class="controls span3">
                                                        <asp:TextBox ID="txt_sdate" runat="server" CssClass="span3 " Width="220px" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                        <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label span3">To Date</label>
                                                    <div class="controls span3">
                                                        <asp:TextBox ID="txt_edate" runat="server" CssClass="span3" Width="220px" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                        <asp:Image ID="img_t" runat="server" ImageUrl="~/leave/images/clndr.gif" />
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
                                                <label class="control-label span3">From Time</label>
                                                <div class="controls span3">
                                                    <asp:TextBox ID="txtftime" runat="server" CssClass="blue1" Enabled="False"></asp:TextBox>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">To Time</label>
                                                <div class="controls span3">
                                                    <asp:TextBox ID="txttotime" runat="server" CssClass="blue1" Enabled="False"></asp:TextBox>
                                                    <asp:Image ID="imgouttime" runat="server" ImageUrl="~/leave/images/clndr.gif" />
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
                                                <label class="control-label span3">Add Comment</label>
                                                <div class="controls span3">
                                                    <asp:TextBox ID="txt_comment" runat="server" CssClass="span3" Width="220px" TextMode="MultiLine"
                                                        Height="40px"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btn_sbmit" runat="server" CssClass="btn btn-success pull-right " Text="Update" OnClick="btn_sbmit_Click" OnClientClick="return ValidateOD();" Style="margin-right: 5px" />
                                                <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info pull-right " Text="Reset" OnClick="btn_reset_Click" Style="margin-right: 5px" />
                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                                <asp:HiddenField ID="hidd_leaveapplyid" runat="server" />
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



