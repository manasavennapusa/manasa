<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewLinemangerReports.aspx.cs" Inherits="Training_ViewLinemangerReports" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartHR</title>
    <link href="../icomoon/style.css" rel="stylesheet" />

    <script src="js/popup.js" type="text/javascript"></script>

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <link href="js/StyleSheet.css" rel="stylesheet" />

</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%-- <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="updatepannel1" DisplayAfter="1"
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
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <%--  <asp:UpdatePanel ID="updatepannel1" runat="server">
                <ContentTemplate>--%>
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2>Team Members Training Report</h2>
                    </div>
                  
                    <div class="clearfix"></div>
                </div>
                <%--<div class="row-fluid">
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
                                            <label style="width:120px" class="control-label span1">Work Location</label>
                                            <div class="span2">
                                                <asp:DropDownList ID="drpbranch" runat="server" CssClass="span2" Height="" Width="200px"
                                                    DataSourceID="sql_data_branch" DataTextField="branch_name" DataValueField="Branch_Id"
                                                    OnDataBound="drpbranch_DataBound" AutoPostBack="True" OnSelectedIndexChanged="drpbranch_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:SqlDataSource
                                                    ID="sql_data_branch" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail] order by branch_name"></asp:SqlDataSource>
                                            </div>

                                              <label class="control-label span2">Department Type</label>
                                            <div class="span2">
                                                <asp:DropDownList ID="dept_type" runat="server" CssClass="span2" Height="" Width="200px"                                                 
                                                    OnDataBound="dept_type_DataBound" AutoPostBack="True" OnSelectedIndexChanged="dept_type_SelectedIndexChanged">
                                                </asp:DropDownList>  <%-- DataSourceID="SqlDataSource5" DataTextField="dept_type_name" DataValueField="dept_type_id"--%>
                                                <%--<asp:SqlDataSource
                                                    ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="select dept_type_id,dept_type_name from tbl_internate_department_type order by dept_type_name"></asp:SqlDataSource>--%
                                            </div>

                                            <label class="control-label span2">Department</label>
                                            <div class=" span2">
                                                <asp:DropDownList ID="drpdepartment" runat="server" AutoPostBack="true"
                                                    OnSelectedIndexChanged="drpdepartment_SelectedIndexChanged" CssClass="span2" Height=""
                                                    Width="200px" OnDataBound="drpdepartment_DataBound">
                                                </asp:DropDownList><%-- DataSourceID="SqlDataSource2" DataTextField="department_name" DataValueField="departmentid" --%>
                                               <%--   <asp:SqlDataSource
                                                    ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="select departmentid,department_name from tbl_internate_departmentdetails order by department_name"></asp:SqlDataSource>--%
                                            </div>
                                           
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls-row">
                                             <label style="width:120px" class="control-label span2 ">Designation</label>
                                            <div class=" span2">
                                                <asp:DropDownList ID="drpdegination" runat="server" CssClass="span2" Width="200px" 
                                                    OnDataBound="dd_designation_DataBound">
                                                </asp:DropDownList> <%--DataSourceID="SqlDataSource1" DataTextField="designationname" DataValueField="id"--%>
                                             <%--   <asp:SqlDataSource
                                                    ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="select id,designationname from dbo.tbl_intranet_designation order by designationname "></asp:SqlDataSource>--%
                                            </div>

                                            <label class="control-label span2">Employee Role</label>
                                            <div class=" span2">
                                                <asp:DropDownList ID="drprole" runat="server" Height="" CssClass="span2" Width="200px"
                                                    DataSourceID="Sql_data_role" DataTextField="role" DataValueField="id" OnDataBound="drprole_DataBound">
                                                    <asp:ListItem Text="-Select Employee Role-" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:SqlDataSource
                                                    ID="Sql_data_role" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [role] FROM [tbl_intranet_role] order by role"></asp:SqlDataSource>

                                            </div>
                                            
                                            <label class="control-label span2 ">Emp Code</label>
                                            <div class="span2">
                                                <asp:TextBox ID="txt_employee" runat="server" CssClass="span2" Width="170px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_employee"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Line Manager" ValidationGroup="d"
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('pickemployee1.aspx?role=13&empcode=<%=txt_employee.Text.ToString() %>');" title="Pick Employee"><i class="icon-user" style="position:absolute; margin-left:15px; margin-top:6px"></i></a>
                                            </div>
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
                </div>--%>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="trigrid"  runat="server" DataKeyNames="id" AutoGenerateColumns="False" OnPreRender="trigrid_PreRender"
                                     EmptyDataText="No such employee exists !" class="table table-striped table-bordered table-hover table-checkable table-responsive" 
                                     AllowSorting="true">
                                        <Columns>
                                             <asp:TemplateField HeaderText="Training Id" Visible="false" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lid" runat="server" Text='<%# Bind ("id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Training Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("trainingcode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Training Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("training_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="From Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("FromDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="To Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind ("ToDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department">
                                                <ItemTemplate>
                                                    <asp:Label ID="l5" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="l7" runat="server" Text='<%# Bind ("dept_id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ModuleName">
                                                <ItemTemplate>
                                                    <asp:Label ID="l6" runat="server" Text='<%# Bind ("modulename") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                         <%--    <asp:HyperLinkField DataNavigateUrlFields="trainingcode,FromDate,ToDate,modulename,dept_id" DataNavigateUrlFormatString="edittrainingschedule.aspx?trainingcode={0}&FromDate={1}&ToDate={2}&modulename={3}&dept_id={4}"
                                                NavigateUrl="edittrainingschedule.aspx"  Text="&lt;img src='../images/edit.png'/&gt;">
                                                <HeaderStyle CssClass="" />
                                            </asp:HyperLinkField>--%>

                                            <asp:HyperLinkField DataNavigateUrlFields="trainingcode,FromDate,ToDate,modulename,dept_id,id" DataNavigateUrlFormatString="viewLinemangerEmployee.aspx?trainingcode={0}&FromDate={1}&ToDate={2}&modulename={3}&dept_id={4}&id={5}"
                                                NavigateUrl="viewLinemangerEmployee.aspx" Text="&lt;img src='../images/view.png' /&gt;">
                                            </asp:HyperLinkField>

                                        </Columns>
                                    </asp:GridView>

                                    <div class="clearfix"></div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>

    </form>
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#trigrid').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>

