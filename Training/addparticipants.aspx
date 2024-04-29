<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addparticipants.aspx.cs" Inherits="Training_AddParticipants"
    Title="SmartDrive Labs Technologies India Pvt. Ltd. : Branch View" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/blue1.css" rel="stylesheet" />
    <style type="text/css">
        .star {
            content: " *";
            margin-left: 5px;
            color: red;
        }

         .dataTables_scrollBody
        {
            margin-top: -11px;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="SM1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hdnId" runat="server" />

        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <asp:Label ID="lblheadingcreate" runat="server"><h2>Add Need Participants</h2></asp:Label>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Search Employee Master 
                                </div>
                            </div>


                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <div class="controls-row">
                                            <label style="width: 120px" class="control-label span1">Work Location</label>
                                            <div class="span2">
                                                <asp:DropDownList ID="drpbranch" runat="server" CssClass="span2" Height="" Width="200px"
                                                    OnDataBound="drpbranch_DataBound" AutoPostBack="True" OnSelectedIndexChanged="drpbranch_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <%-- DataSourceID="sql_data_branch" DataTextField="branch_name" DataValueField="Branch_Id"--%>
                                                <%--  <asp:SqlDataSource
                                                    ID="sql_data_branch" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail] order by branch_name"></asp:SqlDataSource>--%>
                                            </div>

                                            <label class="control-label span2">Department Type</label>
                                            <div class="span2">
                                                <asp:DropDownList ID="dept_type" runat="server" CssClass="span2" Height="" Width="200px"
                                                    OnDataBound="dept_type_DataBound" AutoPostBack="True" OnSelectedIndexChanged="dept_type_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <%-- DataSourceID="SqlDataSource5" DataTextField="dept_type_name" DataValueField="dept_type_id"--%>
                                                <asp:SqlDataSource
                                                    ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="select dept_type_id,dept_type_name from tbl_internate_department_type order by dept_type_name"></asp:SqlDataSource>
                                                -
                                            </div>

                                            <label class="control-label span2">Department</label>
                                            <div class=" span2">
                                                <asp:DropDownList ID="drpdepartment" runat="server" AutoPostBack="true"
                                                    OnSelectedIndexChanged="drpdepartment_SelectedIndexChanged" CssClass="span2" Height=""
                                                    Width="200px" OnDataBound="drpdepartment_DataBound">
                                                </asp:DropDownList><%-- DataSourceID="SqlDataSource2" DataTextField="department_name" DataValueField="departmentid" --%>
                                                <asp:SqlDataSource
                                                    ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="select departmentid,department_name from tbl_internate_departmentdetails order by department_name"></asp:SqlDataSource>
                                            </div>

                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <div class="controls-row">
                                            <label style="width: 120px" class="control-label span2 ">Training id</label>
                                            <div class=" span2">
                                                <asp:DropDownList ID="trainingid" runat="server" AutoPostBack="true" CssClass="span2" Width="200px"
                                                    OnDataBound="trainingid_DataBound" OnSelectedIndexChanged="trainingid_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <%--DataSourceID="SqlDataSource1" DataTextField="designationname" DataValueField="id"--%>
                                                <asp:SqlDataSource
                                                    ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="select id,designationname from dbo.tbl_intranet_designation order by designationname "></asp:SqlDataSource>
                                            </div>
                                            <label class="control-label span2">Training Name</label>
                                            <div class=" span2">
                                                <asp:DropDownList ID="drpcode" runat="server" Height="" CssClass="span2" Width="200px"
                                                    OnDataBound="drpcode_DataBound" OnSelectedIndexChanged="drpcode_SelectedIndexChanged">
                                                    <%--<asp:ListItem Text="-Select Employee Role-" Value="0"></asp:ListItem>--%>
                                                </asp:DropDownList><%-- DataSourceID="Sql_data_role" DataTextField="role" DataValueField="id" OnDataBound="drprole_DataBound">--%>
                                                <asp:SqlDataSource
                                                    ID="Sql_data_role" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [role] FROM [tbl_intranet_role] order by role"></asp:SqlDataSource>

                                            </div>
                                            <%--  <label class="control-label span2 ">Training Code</label>
                                             <div class=" span2">
                                                <asp:DropDownList ID="drpcodename" runat="server" Height="" CssClass="span2" Width="200px"
                                                   OnDataBound="drpcodename_DataBound" OnSelectedIndexChanged="drpcodename_SelectedIndexChanged" >
                                                    <%--<asp:ListItem Text="-Select Employee Role-" Value="0"></asp:ListItem>--%
                                                </asp:DropDownLis%-- DataSourceID="Sql_data_role" DataTextField="role" DataValueField="id" OnDataBound="drprole_DataBound">--%
                                                <asp:SqlDataSource
                                                    ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [role] FROM [tbl_intranet_role] order by role"></asp:SqlDataSource>

                                            </div>    --%>
                                            <br />
                                            <br />
                                            <br />
                                            <div class="form-actions no-margin" style="text-align: right">
                                                <asp:Button ID="btn_search" runat="server" CssClass="btn btn-primary pull-right" Text="Search" OnClick="btn_search_Click" />&nbsp;
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Employee Details
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">

                                    <asp:GridView ID="Grid_Addparticipants"
                                        runat="server" DataKeyNames="empcode"
                                        AutoGenerateColumns="False"
                                        EmptyDataText="No such employee exists !"
                                        class="table table-condensed table-striped table-hover table-bordered pull-left"
                                        OnPreRender="Grid_Addparticipants_PreRender1">
                                        <Columns>

                                           <%-- <asp:TemplateField HeaderText="TrainingID">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l7" runat="server" Text='<%# Bind ("id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Employee Code">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="16%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l0" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                           <%-- <asp:TemplateField HeaderText="Training Code">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("training_code") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            <%--<asp:TemplateField HeaderText="Training Name">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("training_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Employee Name">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="22%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("emp_fname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Designation">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Department">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="13%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l5" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Branch">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l6" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Select" HeaderStyle-Width="4px">
                                                <HeaderTemplate>
                                                    Select All 
                                                         <asp:CheckBox ID="Grid_Addparticipants_chkSelectAll" AutoPostBack="true" runat="server" OnCheckedChanged="Grid_Addparticipants_chkSelectAll_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <%-- <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:intranetConnectionString  %>"
                                        runat="server" SelectCommand="sp_leave_fetch_emp_detail" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                            <asp:Parameter DefaultValue="" Name="emp_fname" Type="String" />
                                            <asp:Parameter DefaultValue="0" Name="desg" Type="Int32" />
                                            <asp:Parameter DefaultValue="0" Name="branch" Type="Int32" />
                                            <asp:Parameter Name="status" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>--%>
                                    <div class="clearfix"></div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="form-actions no-margin" runat="server" id="div_btn">
                    <%--<asp:Button ID="btn_cancel" runat="server" CssClass="btn btn-danger pull-right " Style="margin-right: 5px"
                        OnClick="btn_cancel_Click" Text="Reject" />&nbsp;&nbsp;--%>
                    <asp:Button ID="btn_approve" runat="server" Style="margin-right: 5px" CssClass="btn btn-info pull-right " Text="Submit" OnClick="btn_approve_Click" />

                </div>
            </div>
        </div>

    </form>

    <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.js"></script>
        <script src="../js/moment.js"></script>

        <!-- Data tables JS -->

        <script src="../js/jquery.dataTables.js"></script>

        <!-- Sparkline Chart JS -->
        <script src="../js/sparkline.js"></script>

        <!-- Easy Pie Chart JS -->
        <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

        <!-- Tiny scrollbar js -->
        <script src="../js/tiny-scrollbar.js"></script>

        <!-- Custom Js -->
        <script src="../js/theming.js"></script>
        <script src="../js/custom.js"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script src="../js/tiny-scrollbar.js"></script>

        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>

   <%-- <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#Grid_Addparticipants').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>--%>

     <script type="text/javascript">
         //Data Tables
         $(document).ready(function () {
             $('#Grid_Addparticipants').dataTable({
                 //bFilter: false,
                 //bInfo: false,
                 bPaginate: false,
                 sScrollY: "300px",
                 sScrollCollapse: true
             });
         });

         //Data Tables
         $(document).ready(function () {
             $('#empgrid').dataTable({
                 //bFilter: false,
                 //bInfo: false,
                 bPaginate: false,
                 sScrollY: "300px",
                 sScrollCollapse: true
             });
         });
        </script>


    
</body>
</html>
