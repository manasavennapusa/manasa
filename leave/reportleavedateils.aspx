<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportleavedateils.aspx.cs" Inherits="leave_reportleavedateils" %>

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
                            <h2>Employee Leave Balance</h2>
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
                                    <div class="control-group">
                                        <label class="control-label">Employee Name\Code</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="blue1" Width="" onkeypress="return isAlphaNumeric()"></asp:TextBox>
                                        </div>
                                    </div>



                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btn_search" runat="server" CssClass="btn btn-info" Text="Search" OnClick="btn_search_click" />
                                        <asp:Button ID="btn_export" runat="server" CssClass="btn btn-info" OnClick="btn_export_Click" Text="Export" />
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
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Leave Balance Details
                                    </div>
                                </div>
                                <div style="padding:10px;">
                                    <table>
                                        <tr>
                                            <td>Search : &nbsp;&nbsp;&nbsp;
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Txt_Search" runat="server" OnTextChanged="Txt_Search_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="widget-body" style="height:400px;overflow-y:scroll">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="empgrid" runat="server"
                                            AutoGenerateColumns="False" EmptyDataText="No records found!!"
                                            CssClass="table table-condensed table-striped table-hover table-bordered pull-left" OnPreRender="empgrid_PreRender">
                                            <Columns>
                                                 <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="8%">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblempcode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <a class="lable lable-primary" href="javascript:void(window.open('myleavebalance.aspx?empcode=<%# DataBinder.Eval(Container.DataItem, "empcode") %>', 'title', 'height=300,width=700,left=300.top=40'));"><%#DataBinder.Eval(Container.DataItem, "empcode")%></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                               
                                               <%-- <asp:TemplateField HeaderText="Card No." HeaderStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("card_no") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                 <asp:TemplateField HeaderText="Leave Type" HeaderStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_lv_type" runat="server" Text='<%# Bind ("leavename") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Entitled Days" HeaderStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_entitled_days" runat="server" Text='<%# Bind ("entitled_days") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Used Days" HeaderStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Used" runat="server" Text='<%# Bind ("used") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Leave balance" HeaderStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_balance" runat="server" Text='<%# Bind ("balance") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Grade" HeaderStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l5" runat="server" Text='<%# Bind ("grade") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l6" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Department" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l7" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Work Location" HeaderStyle-Width="9%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l8" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                              <%--  <asp:TemplateField HeaderText="Date of Joining" HeaderStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l9" runat="server" Text='<%# Bind ("emp_doj") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
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
       <%-- <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#empgrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>--%>
    </form>
</body>
</html>
