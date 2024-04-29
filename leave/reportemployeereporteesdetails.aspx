<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportemployeereporteesdetails.aspx.cs" Inherits="leave_reportemployeereporteesdetails" %>

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
                            <h2>Approverwise Report </h2>
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
                                        <label class="control-label">Approver Name\Code</label>
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
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Approverwise Report
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="empgrid" runat="server" EmptyDataText="No records found!!"
                                            CellPadding="4" Width="100%" AutoGenerateColumns="False" CssClass="table table-hover table-striped table-bordered table-highlight-head" OnPreRender="empgrid_PreRender">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="14%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="28%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="28%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Work Location" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="13%">
                                                    <ItemTemplate>
                                                        <a class="link05" href="javascript:void(window.open('myemployees.aspx?empcode=<%#DataBinder.Eval(Container.DataItem, "empcode")%>&name=<%#DataBinder.Eval(Container.DataItem, "name")%>','title','height=200,width=700,left=200,top=20',resizable='no'));">Sub-employee List</a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                            <FooterStyle CssClass="frm-lft-clr123" />
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
                $('#empgrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>
