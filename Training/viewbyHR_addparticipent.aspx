<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewbyHR_addparticipent.aspx.cs" Inherits="Training_viewbyHR_addparticipent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script type="text/javascript" src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css@vd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />


</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Participants</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>


                        <div class="row-fluid">
                            <div class="span12">
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
                                                <div class="controls-row" visible="false" runat="server">
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
                                                    <label class="control-label span2">Module Name</label>
                                                    <div class=" span2">
                                                        <asp:DropDownList ID="drpcode" runat="server" Height="" CssClass="span2" Width="200px"
                                                            OnDataBound="drpcode_DataBound" OnSelectedIndexChanged="drpcode_SelectedIndexChanged">
                                                            <%--<asp:ListItem Text="-Select Employee Role-" Value="0"></asp:ListItem>--%>
                                                        </asp:DropDownList><%-- DataSourceID="Sql_data_role" DataTextField="role" DataValueField="id" OnDataBound="drprole_DataBound">--%>
                                                        <asp:SqlDataSource
                                                            ID="Sql_data_role" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [role] FROM [tbl_intranet_role] order by role"></asp:SqlDataSource>

                                                    </div>
                                                    <%--<label class="control-label span2 ">Emp Code</label>
                                            <div class="span2">
                                                <asp:TextBox ID="txt_employee" runat="server" CssClass="span2" Width="170px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_employee"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Line Manager" ValidationGroup="d"
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('pickemployee1.aspx?role=13&empcode=<%=txt_employee.Text.ToString() %>');" title="Pick Employee"><i class="icon-user" style="position:absolute; margin-left:15px; margin-top:6px"></i></a>
                                            </div>--%>
                                                     </div>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <div class="form-actions no-margin" style="text-align: right">
                                                        <asp:Button ID="btn_search" runat="server" CssClass="btn btn-primary pull-right" Text="Search" OnClick="btn_search_Click" />&nbsp;
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
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">

                                            <asp:GridView ID="Grid_Addparticipantsbyuser"
                                                runat="server" DataKeyNames="empcode"
                                                AutoGenerateColumns="False" OnRowDeleting="Grid_Addparticipantsbyuser_RowDeleting"
                                                EmptyDataText="No such employee exists !" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive"
                                                OnPreRender="Grid_Addparticipantsbyuser_PreRender">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="TrainingID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltrainingid" runat="server" Text='<%# Bind ("trining_id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Employee Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempcode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Training Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltraincode" runat="server" Text='<%# Bind ("training_code") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Training Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltraininame" runat="server" Text='<%# Bind ("training_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Employee Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempname" runat="server" Text='<%# Bind ("emp_fname") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="From Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfromdate" runat="server" Text='<%# Bind ("FromDate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="To Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltodate" runat="server" Text='<%# Bind ("ToDate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Module Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblmodulename" runat="server" Text='<%# Bind ("modulename") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <%-- <asp:TemplateField HeaderText="Designation">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldesing" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                                    <asp:TemplateField HeaderText="Department">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldep" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                   <%-- <asp:TemplateField HeaderText="Branch" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblbranc" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                     <asp:TemplateField HeaderText="depid" Visible="false" runat="server">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbld" runat="server" Text='<%# Bind ("departmentid") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                  <%--       <asp:HyperLinkField HeaderText="View" DataNavigateUrlFields="empcode,FromDate,ToDate,modulename" DataNavigateUrlFormatString="viewbyaddneedparticipant.aspx?empcode={0}&FromDate={1}&ToDate={2}&modulename={3}"
                                                    Text="View">
                                                    <ControlStyle CssClass="btn btn-info" />
                                                </asp:HyperLinkField>
                                      
                                                    
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkdelet" runat="server" CommandName="Delete" Text="Delete"
                                                                OnClientClick="return confirm('Are you sure, you want to delete');" CssClass="btn btn-info"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>        --%>




                                                        <asp:HyperLinkField DataNavigateUrlFields="empcode,FromDate,ToDate,modulename,training_name,departmentid" HeaderText="View" DataNavigateUrlFormatString="viewbyaddneedparticipant.aspx?empcode={0}&FromDate={1}&ToDate={2}&modulename={3}&training_name={4}&departmentid={5}&back=1"
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

                        <%-- <div class="form-actions no-margin">
                                              <%--  <asp:Button ID="btn_select" runat="server" Text="Select All" CssClass="btn btn-primary" OnClick="btn_select_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                 <asp:Button ID="btn_deselect" runat="server" Text="DeSelect All" CssClass="btn btn-primary" OnClick="btn_deselect_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%
                                                 <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btn_submit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btn_back" runat="server" CssClass="btn btn-primary" OnClick="btn_back_Click"
                                                    Text="Back" />
                        </div>--%>

                        <span id="message" runat="server"></span>
                        <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT tbl_intranet_companydetails.companyname, tbl_intranet_branch_detail.branch_name, tbl_intranet_branch_detail.Branch_Id,tbl_intranet_branch_detail.branch_code, tbl_intranet_branch_detail.esstt_date, tbl_intranet_branch_detail.region, tbl_intranet_branch_detail.add1 + ', '  + tbl_intranet_branch_detail.city + ', '+ tbl_intranet_branch_detail.state+ ', ' + tbl_intranet_branch_detail.country + ' ' + tbl_intranet_branch_detail.zipcode as address FROM tbl_intranet_branch_detail INNER JOIN tbl_intranet_companydetails ON tbl_intranet_branch_detail.Company_id = tbl_intranet_companydetails.companyid"
                            ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                            DeleteCommand="DELETE FROM [tbl_intranet_branch_detail] WHERE [branch_id] = @branch_id"></asp:SqlDataSource>--%>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </form>
    <script type="text/javascript" src="../js/jquery.min.js"></script>

    <script type="text/javascript" src="../js/jquery.dataTables.js"></script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#Grid_Addparticipantsbyuser').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>
