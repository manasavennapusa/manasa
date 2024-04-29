<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leaveencashmentform.aspx.cs" Inherits="leave_leaveencashmentform" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <link href="js/StyleSheet.css" rel="stylesheet" />
    <script src="js/popup.js"></script>
</head>
<body>
    <form id="myForm" runat="server">
        <script type="text/javascript">

            function ValidateEmpcode() {
                var empcode = document.getElementById('<%=txt_employee.ClientID%>');
                var preyear = document.getElementById('<%=drpyear.ClientID%>');
                if (empcode.value == "") {
                    alert("Please select empcode");
                    return false;

                }
                if (preyear.value == "0" )
                {
                    alert("Please select previous Financial Year");
                    return false;

                }
                return true

            }
            function ValidateEncash() {
                var leaveid = document.getElementById('<%=ddl_leave.ClientID%>');
                var encashdays = document.getElementById('<%=txtEncashDays.ClientID%>');
                var fyear = document.getElementById('<%=drpyear.ClientID%>');
                var month = document.getElementById('<%=dd_month.ClientID%>');
                var empcode = document.getElementById('<%=txt_employee.ClientID%>');
                if (empcode.value == "") {
                    alert("Please select empcode");
                    return false;
                }
                if (leaveid.value == 0) {
                    alert("Please Select Leave Type");
                    return false;
                }
                if (encashdays.value == "0.0") {
                    alert("Please Enter Encash Days.");
                    return false;
                }

                if (fyear.value == "--Select Financial Year--") {
                    alert("Please Select Financial Year");
                    return false;
                }
                if (month.value == "0") {
                    alert("Please Select Month.");
                    return false;
                }
                if (encashdays.value < 0) {
                    alert("Please Enter Encashment Days greater than 0.");
                    return false;
                }
                return true;
            }
            function isKey(keyCode) {
                return false;
            }
        </script>
        <script type="text/javascript">
            function IsNumericDot(evt) {
                var theEvent = evt || window.event;
                var key = theEvent.keyCode || theEvent.which;
                key = String.fromCharCode(key);
                var regex = /[0-9]|\./;
                if (!regex.test(key)) {
                    theEvent.returnValue = false;
                    if (theEvent.preventDefault) theEvent.preventDefault();
                }
            }
        </script>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%-- <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
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
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="page-header">
                        <div class="pull-left">
                            <h2>Leave Encashment Form</h2>
                        </div>

                        <div class="clearfix"></div>
                    </div>
                    <div class="row-fluid">
                        <div class="widget">
                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Leave Encashment Form
                                                     
                                        </div>
                                        <a data-toggle="modal" id="lslink" visible="false" runat="server" href="#myModal1" class="btn btn-info pull-right pull-right" onclick="return ValidateEmpcode();">Leave Card Status</a>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">

                                                <label class="control-label span3 ">Employee Code/Name</label>
                                                <div class="controls span4">
                                                    <asp:TextBox ID="txt_employee" runat="server" Width="220px" CssClass="span4" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                    <a href="JavaScript:newPopup1('PickEmployee.aspx');"><i class="icon-user"></i>Pick Employee</a>
                                                </div>
                                                <div class="controls span1">
                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info pull-right " Text="Get Leave Card" OnClick="btnSubmit_Click" OnClientClick="return ValidateEmpcode();" />
                                                </div>

                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Leave Type</label>
                                                <div class="controls span3">
                                                    <asp:DropDownList ID="ddl_leave" runat="server" CssClass="span4" Width="220px" OnSelectedIndexChanged="ddl_leave_SelectedIndexChanged" AutoPostBack="true" OnDataBound="ddl_leave_DataBound">
                                                     <%--   <asp:ListItem Value="0">--Select--</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="control-group" style="display:none">
                                                <label class="control-label span3">Leave Balance as on Date</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lblCurBalance" runat="server">0.0</asp:Label>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Encashment Limit</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lblEncashLimit" runat="server" Width="220px">0.0</asp:Label>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Encashment Days</label>
                                                <div class="controls span3">
                                                    <asp:TextBox ID="txtEncashDays" runat="server" CssClass="span4" Width="220px" onkeypress="return IsNumericDot(event);" ondrop="return false;" onpaste="return false;">0.0</asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Financial Year</label>
                                                <div class="controls span3">
                                                    <asp:DropDownList ID="drpyear" runat="server" CssClass="span4" Width="220px">
                                                      <%--  <asp:ListItem Value="0">--Select Financial Year--</asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Month</label>
                                                <div class="controls span3">
                                                    <asp:DropDownList ID="dd_month" runat="server" CssClass="span3" Width="220px" OnDataBound="dd_month_DataBound">
                                                        <asp:ListItem Value="0">--Select Month--</asp:ListItem>
                                                        <asp:ListItem Value="1">Jan</asp:ListItem>
                                                        <asp:ListItem Value="2">Feb</asp:ListItem>
                                                        <asp:ListItem Value="3">Mar</asp:ListItem>
                                                        <asp:ListItem Value="4">Apr</asp:ListItem>
                                                        <asp:ListItem Value="5">May</asp:ListItem>
                                                        <asp:ListItem Value="6">Jun</asp:ListItem>
                                                        <asp:ListItem Value="7">Jul</asp:ListItem>
                                                        <asp:ListItem Value="8">Aug</asp:ListItem>
                                                        <asp:ListItem Value="9">Sep</asp:ListItem>
                                                        <asp:ListItem Value="10">Oct</asp:ListItem>
                                                        <asp:ListItem Value="11">Nov</asp:ListItem>
                                                        <asp:ListItem Value="12">Dec</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Comments</label>
                                                <div class="controls span3">
                                                    <asp:TextBox ID="txtcomments" runat="server" CssClass="span4" Width="220px" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btn_sbmit" runat="server" CssClass="btn btn-info pull-right " Text="Submit" OnClick="btn_sbmit_Click" OnClientClick="return ValidateEncash();" />
                                                <asp:HiddenField ID="hdnpolicyid" runat="server" />
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                    <div id="myModal1" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                ×</button>
                            <h4 id="myModalLabel">Leave Card Status
                            </h4>
                        </div>
                        <div class="modal-body">
                            <iframe src="leaveencashmentBalance.aspx" width="100%" frameborder="0" scrolling="yes" height="300px"></iframe>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>
    <!-- Custom Js -->
    <script src="../js/theming.js"></script>
    <%--  <script src="../js/custom.js"></script>--%>
</body>
</html>



