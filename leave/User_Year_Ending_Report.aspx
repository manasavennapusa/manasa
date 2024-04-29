<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_Year_Ending_Report.aspx.cs" Inherits="leave_User_Year_Ending_Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script src="js/popup.js"></script>
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

        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                   
                    <div class="page-header">
                        <div class="pull-left">
                            <h2> My Year Ending Leave Report</h2>
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
                                   <%-- <div class="control-group">
                                        <label class="control-label">Employee Code</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="span3" Width="" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <a href="JavaScript:newPopup1('PickEmployee.aspx');"><i class="icon-user"></i></a>
                                        </div>
                                    </div>--%>
                                    <div class="control-group">
                                        <label class="control-label">Calender Year</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="Ddl_Calender_Year" runat="server" CssClass="blue1" Height="" OnDataBound="Ddl_Calender_Year_DataBound"
                                                DataSourceID="sql_data_calender" DataTextField="periodname" DataValueField="id">
                                                
                                            </asp:DropDownList>
                                            <asp:SqlDataSource
                                                ID="sql_data_calender" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="select id,periodname from tbl_leave_leaveperiod where status=1"></asp:SqlDataSource>
                                        </div>
                                    </div>
                                   
                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btn_search" runat="server" CssClass="btn btn-info" OnClick="btn_search_Click" Text="Search" OnClientClick="return ValidateData();" />
                                        <asp:Button ID="btn_export" runat="server" CssClass="btn btn-info" OnClick="btn_export_Click" Text="Export" OnClientClick="return ValidateData();" />
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget no-margin">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>My Year Ending Leave Report
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="empleavegrid" runat="server" EmptyDataText="No records found!!" AutoGenerateColumns="False"
                                            DataKeyNames="empcode" OnPreRender="empleavegrid_PreRender" 
                                            CssClass="table table-condensed table-striped table-hover table-bordered pull-left">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Emp Code" HeaderStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Emp Name" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("EmpName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Leave Type" HeaderStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblid" runat="server" Text='<%# Bind ("leavetype") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Policy Name" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("policyname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Carrried Forward" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("CarrriedForward") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Encashed Leaves" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblleave" runat="server" Text='<%# Bind ("EncashedLeaves") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Lapsed Leaves" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldate" runat="server" Text='<%# Bind ("LapsedLeaves") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Opening Balance for current Year" HeaderStyle-Width="20%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblOpeningBalance" runat="server" Text='<%# Bind ("OpeningBalance") %>'></asp:Label>
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
                $('#empleavegrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>

