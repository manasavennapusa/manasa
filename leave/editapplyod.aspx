<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editapplyod.aspx.cs" Inherits="leave_editapplyod" %>

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
                                    <h2>Modify OD Application</h2>
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
                                                    <label class="control-label span3">Status</label>
                                                    <div class="span3">
                                                        <asp:Label ID="lbl_emp_status" runat="server"></asp:Label>
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
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>OD Applilcation
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
                                                    <asp:TextBox ID="txtftime" runat="server" CssClass="blue1" Enabled="False" ></asp:TextBox>
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
                                                <label class="control-label span3">Previous Comment</label>
                                                <div class=" span9">
                                                    <asp:Label ID="lblcomm" runat="server"></asp:Label>
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
                                                <asp:Button ID="btn_sbmit" runat="server" CssClass="btn btn-success pull-right " Text="Update" OnClick="btn_sbmit_Click" />
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


