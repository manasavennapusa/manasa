<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateholiday.aspx.cs" Inherits="attendance_updateholiday" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
        <script type="text/javascript">
            function ValidateData() {

                var year = document.getElementById('<%=ddlyear.ClientID %>');
                var branch = document.getElementById('<%=ddbranch_id.ClientID %>');
                var holidayname = document.getElementById('<%=txtholiday.ClientID %>');
                var date = document.getElementById('<%=txtdate.ClientID %>');

                if (year.value == 0) {
                    alert("Please Select Year");
                    return false;
                }
                if (holidayname.value == "") {
                    alert("Please Enter Hoiday Name");
                    return false;
                }
                if (date.value == "") {
                    alert("Please Enter Date");
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
                                    <h2>Update Holiday</h2>
                                </div>

                                <div class="clearfix"></div>
                            </div>

                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Holiday
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">Year</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddlyear" runat="server" Width="" CssClass="span3" ToolTip="Select year">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Work Location</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddbranch_id" runat="server" Width="220" ToolTip="Select Branch" DataSourceID="SqlDataSource1" DataTextField="branch_name" DataValueField="branch_id" CssClass="blue1" AppendDataBoundItems="True" OnSelectedIndexChanged="ddbranch_id_SelectedIndexChanged" AutoPostBack="true">
                                                        <asp:ListItem Value="0">For all Work Location</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>" SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]"></asp:SqlDataSource>
                                                </div>
                                            </div>
                                             <div class="control-group">
                                                <label class="control-label">Shift</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_shift" runat="server" Width="220" ToolTip="Select shift" CssClass="blue1" OnDataBound="ddl_shift_DataBound">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Name</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtholiday" runat="server" Width="" CssClass="span3" ToolTip="Add Holiday Name" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Detail</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtdetail" runat="server" Width="" CssClass="span3" TextMode="MultiLine" ToolTip="Add detail of the holiday" MaxLength="200" onkeypress="return isalphanumericsplchar()"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Date</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtdate" runat="server" CssClass="span3 datepicker" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                    <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                        <cc1:CalendarExtender
                                                            ID="CalendarExtender1" runat="server" PopupButtonID="img_f" TargetControlID="txtdate">
                                                        </cc1:CalendarExtender>
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btnsbmit" runat="server" Text="Update" CssClass="btn btn-info " OnClick="btnsbmit_Click" OnClientClick="return ValidateData();" ToolTip="Click here to submit the new holiday" />&nbsp;&nbsp;
                                                <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info  " ValidationGroup="nothing" Text="Reset" OnClick="btn_reset_Click" />
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
