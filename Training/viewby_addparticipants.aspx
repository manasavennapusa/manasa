<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewby_addparticipants.aspx.cs" Inherits="Training_viewby_addparticipants" %>

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
                        <asp:Label ID="lblheadingcreate" runat="server"><h2>Add Participants</h2></asp:Label>
                    </div>

                    <div class="clearfix"></div>
                </div>

               <%-- <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    All Query Status
                                </div>
                            </div>
                        </div>
                    </div>
                </div>--%>
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
                                        class="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                        OnPreRender="Grid_Addparticipants_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Employee Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="l0" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Training Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("training_code") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Training Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("training_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Employee Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("emp_fname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Designation">
                                                <ItemTemplate>
                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Department">
                                                <ItemTemplate>
                                                    <asp:Label ID="l5" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Branch">
                                                <ItemTemplate>
                                                    <asp:Label ID="l6" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField HeaderText="TrainingID" Visible="false">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l7" runat="server" Text='<%# Bind ("id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

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

    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#Grid_Addparticipants').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>
