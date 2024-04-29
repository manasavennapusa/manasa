<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hrupdatecompofffforapproval.aspx.cs" Inherits="leave_hrupdatecompofffforapproval" %>

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
            function Validate() {
                var sdate = document.getElementById('<%=txt_fromdate.ClientID%>');
                var edate = document.getElementById('<%=txt_todate.ClientID%>');
                var fullday = document.getElementById('<%=rdofullday.ClientID%>');
                var halfday = document.getElementById('<%=rdohalfday.ClientID%>');
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
                var reason = document.getElementById('<%=txt_reason.ClientID%>');
                var sdate = document.getElementById('<%=txt_fromdate.ClientID%>');
                var edate = document.getElementById('<%=txt_todate.ClientID%>');
                var fullday = document.getElementById('<%=rdofullday.ClientID%>');
                var halfday = document.getElementById('<%=rdohalfday.ClientID%>');

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
                return true;

            }

            function setImage(btnID) {
                var btn = document.getElementById(btnID);
                btn.style.background = 'url(12501270608.gif)';
            }


        </script>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
     <%--   <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
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
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                            <div class="page-header">
                                <div class="pull-left">
                                    <h2>Comp-off Leave</h2>
                                </div>
                               
                                <div class="clearfix"></div>
                            </div>
                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Select Employee 
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
                                                    <div class="controls span3">
                                                        <a href="JavaScript:newPopup1('PickEmployee.aspx');"><i class="icon-user"></i>Pick Employee</a>
                                                    </div>
                                                    <div class="controls span1">
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info pull-right " Text="Get Comp-Off" OnClick="btnSubmit_Click" OnClientClick="return ValidateEmpcode();" />
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
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Comp-off Application
                                        </div>
                                        <div>
                                            <a href="#myModal" id="colink" runat="server" visible="false" role="button" class="btn btn-info pull-right" data-toggle="modal">Comp-off Status</a>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
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
                                            <div id="divfull" visible="true" runat="server">
                                                <div class="control-group">
                                                    <label class="control-label span3">From Date</label>
                                                    <div class="controls span3">
                                                        <asp:TextBox ID="txt_fromdate" runat="server" CssClass="span3" Width="220px"></asp:TextBox>
                                                        <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                        <cc1:CalendarExtender
                                                            ID="CalendarExtender1" runat="server" PopupButtonID="img_f" TargetControlID="txt_fromdate">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label span3">To Date</label>
                                                    <div class="controls span3">
                                                        <asp:TextBox ID="txt_todate" runat="server" CssClass="span3 " Width="220px"></asp:TextBox>
                                                        <asp:Image ID="img_t" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                        <cc1:CalendarExtender
                                                            ID="CalendarExtender2" runat="server" PopupButtonID="img_t" TargetControlID="txt_todate">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="divhalf" visible="false" runat="server">
                                                <div class="control-group">
                                                    <label class="control-label span3">Select Date</label>
                                                    <div class="controls span3">
                                                        <asp:TextBox ID="txtdateone" runat="server" CssClass="span3" Width="220px"></asp:TextBox>
                                                        <asp:Image ID="img_select" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                        <cc1:CalendarExtender ID="Calendarextender3" runat="server" PopupButtonID="img_select" TargetControlID="txtdateone">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">No. of Days</label>
                                                <div class="controls span1">
                                                    <asp:TextBox ID="lbl_no_of_days" runat="server" CssClass="span3" Width="220px" Enabled="False">0</asp:TextBox>
                                                </div>
                                                <div class="controls span2">
                                                    <asp:Button ID="btn_calc" runat="server" Text="Calculate No. of Days" OnClick="btn_calc_Click" CssClass="btn btn-info pull-right " OnClientClick="return Validate();" />
                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>
                                    <div class="widget-body">
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
                                                <label class="control-label span3">Add Comment</label>
                                                <div class="controls span3">
                                                    <asp:TextBox ID="txt_comment" runat="server" CssClass="span3" Width="220px" TextMode="MultiLine"
                                                        Height="40px"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btn_submit" runat="server" Style="margin-right: 5px;" CssClass="btn btn-info pull-right" Text="Submit" OnClientClick="return CheckIsRepeat();" OnClick="btn_submit_Click1" ValidationGroup="v" Enabled="False" />

                                                <asp:Button ID="btn_reset" runat="server" Style="margin-right: 5px;" CssClass="btn btn-info pull-right" Text="Reset" OnClick="btn_reset_Click" />
                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                       <%-- </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnSubmit" />
                        </Triggers>
                    </asp:UpdatePanel>--%>
                    <div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                ×
                            </button>
                            <h4 id="myModalLabel">Comp-off Balance
                            </h4>
                        </div>
                        <div class="modal-body">
                            <table width="100%" class="table table-condensed table-striped table-hover table-bordered pull-left">
                                <tr>
                                    <td class="txt02">Entitled</td>
                                    <td class="txt02">Used</td>
                                    <td class="txt02">Available</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblentitled" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblused" runat="server"></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblavalible" runat="server"></asp:Label></td>
                                </tr>

                            </table>
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



