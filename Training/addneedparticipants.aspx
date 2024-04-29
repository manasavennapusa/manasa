<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addneedparticipants.aspx.cs" EnableEventValidation = "false" Inherits="training_addneedparticipants" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                            <h2>Need Participants</h2>
                        </div>

                        <div class="clearfix"></div>
                    </div>

                    <div class="row-fluid">
                      <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true"  ></span>Search 
                                </div>
                            </div>


                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <div class="controls-row">
                                            <label style="width:120px" class="control-label span1">Work Location</label>
                                            <div class="span2">
                                                <asp:DropDownList ID="drpbranch" runat="server" CssClass="span2" Height="" Width="200px"                                                   
                                                    OnDataBound="drpbranch_DataBound" AutoPostBack="True" OnSelectedIndexChanged="drpbranch_SelectedIndexChanged">
                                                </asp:DropDownList>   <%-- DataSourceID="sql_data_branch" DataTextField="branch_name" DataValueField="Branch_Id"--%>
                                              <%--  <asp:SqlDataSource
                                                    ID="sql_data_branch" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail] order by branch_name"></asp:SqlDataSource>--%>
                                            </div>

                                              <label class="control-label span2">Department Type</label>
                                            <div class="span2">
                                                <asp:DropDownList ID="dept_type" runat="server" CssClass="span2" Height="" Width="200px"                                                 
                                                    OnDataBound="dept_type_DataBound" AutoPostBack="True" OnSelectedIndexChanged="dept_type_SelectedIndexChanged">
                                                </asp:DropDownList>  <%-- DataSourceID="SqlDataSource5" DataTextField="dept_type_name" DataValueField="dept_type_id"--%>
                                                <asp:SqlDataSource
                                                    ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="select dept_type_id,dept_type_name from tbl_internate_department_type order by dept_type_name"></asp:SqlDataSource>
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

                                  <%--  <div class="control-group">
                                        <div class="controls-row">
                                             <label style="width:120px" class="control-label span2 ">Training id</label>
                                    <div class=" span2">
                                                <asp:DropDownList ID="trainingid" runat="server" AutoPostBack="true" CssClass="span2" Width="200px" 
                                                    OnDataBound="trainingid_DataBound" OnSelectedIndexChanged="trainingid_SelectedIndexChanged">
                                                </asp:DropDownList> <%--DataSourceID="SqlDataSource1" DataTextField="designationname" DataValueField="id"--%>
                                              <%-- <asp:SqlDataSource
                                                    ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="select id,designationname from dbo.tbl_intranet_designation order by designationname "></asp:SqlDataSource>
                                            </div>
                                            <label class="control-label span2">Module Name</label>
                                            <div class=" span2">
                                                <asp:DropDownList ID="drpcode" runat="server" Height="" CssClass="span2" Width="200px"
                                                   OnDataBound="drpcode_DataBound" OnSelectedIndexChanged="drpcode_SelectedIndexChanged" >--%>
                                                    <%--<asp:ListItem Text="-Select Employee Role-" Value="0"></asp:ListItem>--%>
                                               <%-- </asp:DropDownList>--%><%-- DataSourceID="Sql_data_role" DataTextField="role" DataValueField="id" OnDataBound="drprole_DataBound">--%>
                                               <%-- <asp:SqlDataSource
                                                    ID="Sql_data_role" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [role] FROM [tbl_intranet_role] order by role"></asp:SqlDataSource>

                                            </div>                  --%>                          
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
                                          <%-- <br />
                                            <br />--%>
                                            <br />                                       
                                            <div class="form-actions no-margin" style="text-align: right">
                                                <asp:Button ID="btn_search" runat="server" CssClass="btn btn-primary pull-right" Text="Search" OnClick="btn_search_Click" />&nbsp;
                                                
                                            </div>
                                      <%--  </div>
                                    </div>--%>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <%--  </ContentTemplate>
                    </asp:UpdatePanel>--%>
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget no-margin">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                     
                                    </div>
                                    <div>
                                           <asp:Button ID="btn_export" runat="server" CssClass="btn btn-info pull-right"  OnClick="btn_export_Click" Text="Export" OnClientClick="return ValidateData();" />
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                                                <asp:GridView ID="Grid_Addparticipants"
                                        runat="server" DataKeyNames="empcode"    OnPreRender="Grid_Addparticipants_PreRender"                                   
                                        AutoGenerateColumns="False" OnRowDeleting="Grid_Addparticipants_RowDeleting" 
                                        EmptyDataText="No such employee exists !"
                                        class="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                       >
                                        <Columns>

                                             <asp:TemplateField HeaderText="Trainigsch" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltrd" runat="server" Text='<%# Bind ("id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Employee Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempcode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="FromDate" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfromdate" runat="server" Text='<%# Bind ("FromDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="ToDate" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltodate" runat="server" Text='<%# Bind ("ToDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Module Name" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmodulaname" runat="server" Text='<%# Bind ("modulename") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                              <asp:TemplateField HeaderText="Training Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltraincode" runat="server" Text='<%# Bind ("training_code") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Training Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltrainname" runat="server" Text='<%# Bind ("training_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Employee Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempname" runat="server" Text='<%# Bind ("emp_fname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Department">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldep" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="depid" Visible="false" runat="server">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbld" runat="server" Text='<%# Bind ("departmentid") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:HyperLinkField DataNavigateUrlFields="empcode,fromdate" DataNavigateUrlFormatString="viewbyaddneedparticipant.aspx?empcode={0}&fromdate={1}"
                                                Text="View" ControlStyle-CssClass="btn btn-info">
                                            </asp:HyperLinkField>--%>

                                         <%--   <asp:HyperLinkField HeaderText="View" DataNavigateUrlFields="empcode,FromDate,ToDate,modulename" DataNavigateUrlFormatString="viewbyaddneedparticipant.aspx?empcode={0}&FromDate={1}&ToDate={2}&modulename={3}"
                                                    Text="View">
                                                    <ControlStyle CssClass="btn btn-info" />
                                                </asp:HyperLinkField>--%>
                                            
                                                  <asp:HyperLinkField DataNavigateUrlFields="empcode,FromDate,ToDate,modulename,training_name,departmentid" HeaderText="View" DataNavigateUrlFormatString="viewbyaddneedparticipant.aspx?empcode={0}&FromDate={1}&ToDate={2}&modulename={3}&training_name={4}&departmentid={5}&back=0"
                                                NavigateUrl="viewbyaddneedparticipant.aspx" Text="&lt;img src='../images/view.png'/&gt;">

                                                <HeaderStyle CssClass="" />
                                                <ControlStyle CssClass="link05" Width="50%" />
                                            </asp:HyperLinkField>
                                                      <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="10px" ItemStyle-Width="10px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure, you want to delete');"
                                                                Text="&lt;img src='../images/download_delete.png'/&gt;"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                          <%--  <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkdelet" runat="server" CommandName="Delete" Text="&lt;img src='../images/download_delete.png'/&gt;"
                                                        OnClientClick="return confirm('Are you sure, you want to delete');"  CausesValidation="false"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>   --%>  
                                            
                                            <%--<asp:CommandField ShowDeleteButton="true" ButtonType="Button" DeleteText="delete" />     --%>                               

                                        </Columns>
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
                $('#Grid_Addparticipants').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>
