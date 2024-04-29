<%@ Page Language="C#" AutoEventWireup="true" CodeFile="attendancemanualentry.aspx.cs" Inherits="attendance_attendancemanualentry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script src="js/popup.js"></script>
    <script src="js/timepicker.js"></script>

</head>
<body>
    <form id="myForm" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">

                    <div class="page-header">
                        <div class="pull-left">
                            <h2>Attendance Manual Entry</h2>
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
                                        <label class="control-label">Employee Code</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="form-control" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <a href="JavaScript:newPopup1('PickEmployee.aspx');"><i class="icon-user"></i>Pick Employee</a>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Date</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_start_date" runat="server"></asp:TextBox>
                                            <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                                PopupButtonID="img_f" 
                                                TargetControlID="txt_start_date"></cc1:CalendarExtender>

                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">In Time</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtstime" runat="server"></asp:TextBox>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Out Time</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtetime" runat="server"></asp:TextBox>
                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                                        </div>
                                    </div>

                                    <div class="form-actions no-margin">
                                        <asp:Button ID="submitbtn" runat="server" CssClass="btn btn-primary pull-right" Text="Update Attendance" OnClick="submitbtn_Click" />&nbsp; 
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>



