<%@ Page Language="C#" AutoEventWireup="true" CodeFile="generatemonthlyattendancereport.aspx.cs" Inherits="attendance_generatemonthlyattendancereport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script type="text/javascript">
        function ValidateData() {
            var month = document.getElementById('<%=dd_month.ClientID %>');
            var branch = document.getElementById('<%=drpbranch.ClientID %>');
            var year = document.getElementById('<%=ddlYear.ClientID %>');

            if (month.value == 0) {
                alert("Please Select Month");
                return false;
            }
            if (year.value == 0) {
                alert("Please Select Year");
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
                                    <h2>Monthly Report of Attendence</h2>
                                </div>

                                <div class="clearfix"></div>
                            </div>

                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Monthly Report of Attendence
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">Select Month</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="dd_month" runat="server" CssClass="span3" Width="" OnDataBound="dd_month_DataBound">
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
                                                <label class="control-label span3">Year</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="span3">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Work Location</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="drpbranch" runat="server" CssClass="blue1" Height=""
                                                        DataSourceID="sql_data_branch" DataTextField="branch_name" DataValueField="Branch_Id"
                                                        OnDataBound="drpbranch_DataBound" AutoPostBack="True" OnSelectedIndexChanged="drpbranch_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource
                                                        ID="sql_data_branch" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail]"></asp:SqlDataSource>
                                                </div>
                                            </div>
                                            <%-- changed by maruthi--%>
                                            <div class="control-group">
                                                <label class="control-label">Department Type</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddldepatrtmenttype" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddldepatrtmenttype_SelectedIndexChanged" CssClass="span11" Height=""
                                                        Width="230px" OnDataBound="ddldepatrtmenttype_DataBound">
                                                    </asp:DropDownList>
                                                    <%-- <asp:DropDownList ID="ddldepatrtmenttype" runat="server" CssClass="blue1" Height=""
                                                        OnDataBound="ddldepatrtmenttype_DataBound" OnSelectedIndexChanged="ddldepatrtmenttype_SelectedIndexChanged">
                                                    </asp:DropDownList>--%>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Department</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="drpdepartment" runat="server" CssClass="blue1" Height=""
                                                        OnDataBound="drpdepartment_DataBound">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="control-group" style="display: none">
                                                <label class="control-label">Employee Name</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_employee" runat="server" CssClass="blue1" Width="" onkeypress="return isAlphaNumeric()"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btnreport" runat="server" Text="Report" CssClass="btn btn-info" OnClick="btnreport_Click" OnClientClick="return ValidateData();" />&nbsp;
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



