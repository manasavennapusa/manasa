<%@ Page Language="C#" AutoEventWireup="true" CodeFile="generatedatewiseattendancereport.aspx.cs" Inherits="attendance_generatedatewiseattendancereport" %>

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
            function isKey(keyCode) {
                return false;
            }
        </script>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
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
                            <h2>Datewise Attendance</h2>
                        </div>

                        <div class="clearfix"></div>
                    </div>

                    <div class="row-fluid">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Search Employee
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Date</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_sdate" runat="server" Width="200px" CssClass="blue1" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                            <cc1:CalendarExtender ID="cextender" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate" Format="MM/dd/yyyy"></cc1:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Employee Name\Code</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="blue1" Width="" onkeypress="return isAlphaNumeric()"></asp:TextBox>
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
                                    <div class="control-group">
                                        <label class="control-label">Department</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="drpdepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpdepartment_SelectedIndexChanged" CssClass="blue1" Height=""
                                                OnDataBound="drpdepartment_DataBound">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Designation</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="drpdegination" runat="server" CssClass="blue1"
                                                OnDataBound="dd_designation_DataBound">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btn_search" runat="server" CssClass="btn btn-info" Text="Search" OnClick="btn_search_Click" />
                                        <asp:Button ID="btnexport" runat="server" CssClass="btn btn-info" OnClick="btnexport_Click"
                                            Text="Export" ToolTip="Export" />
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <%--   </ContentTemplate>
                    </asp:UpdatePanel>--%>
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget no-margin">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Attendance
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="attendancegrid" runat="server" AutoGenerateColumns="False" EmptyDataText="No records found!!"
                                            CssClass="table table-condensed table-striped table-hover table-bordered pull-left" OnPreRender="attendancegrid_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="25%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblemp" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempcode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Department" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldept" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Day" HeaderStyle-Width="14%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind("dayofweek")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date" HeaderStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind("date")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mode" HeaderStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="mode" runat="server" Text='<%# Bind("mode")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle Height="5px" />
                                        </asp:GridView>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#attendancegrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>

