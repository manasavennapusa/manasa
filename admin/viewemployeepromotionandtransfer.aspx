<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewemployeepromotionandtransfer.aspx.cs" Inherits="admin_viewemployeepromotionandtransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartHR</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <link href="js/StyleSheet.css" rel="stylesheet" />
    <script src="js/popup.js"></script>

</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="dashboard-wrapper" style="margin-left: 0px;">
       
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2>View Employee Promotion/Transfer</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>
          

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Search Type  
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <div class="controls-row" style="margin-left:200px;">
                                            <label style="width: 120px" class="control-label span1">Type</label>
                                            <div class="span2">
                                                <asp:DropDownList ID="drpbranch" runat="server" CssClass="span2" Height="" Width="200px"
                                                    AutoPostBack="True" OnSelectedIndexChanged="drpbranch_SelectedIndexChanged">
                                                    <asp:ListItem Text="--Select--" Value="1"></asp:ListItem>
                                                     <asp:ListItem Text="Employee Promotion" Value="2"></asp:ListItem>
                                                     <asp:ListItem Text="Employee Transfer" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                                
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
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Employee Promotion/Transfer Details
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="empgrid" runat="server" DataKeyNames="empcode" AutoGenerateColumns="False"
                                        EmptyDataText="No such employee exists !" class="table table-condensed table-striped table-hover table-bordered pull-left" OnPreRender="empgrid_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Employee Code">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="16%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l0" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="26%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Role">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("role") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField DataNavigateUrlFields="empcode" HeaderText="View" DataNavigateUrlFormatString="viewpromtiondetails.aspx?empcode={0}"
                                                NavigateUrl="Emp_historydetails.aspx" Text="View">

                                                <HeaderStyle CssClass="" />
                                                <ControlStyle CssClass="link05" Width="50%" />
                                            </asp:HyperLinkField>


                                        </Columns>
                                        <HeaderStyle CssClass="" />
                                        <FooterStyle CssClass="" />
                                        <RowStyle Height="5px" />
                                        <PagerStyle CssClass=""></PagerStyle>
                                    </asp:GridView>

                                    <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:intranetConnectionString  %>"
                                        runat="server" SelectCommand="sp_leave_fetch_emp_detail_history" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                            <asp:Parameter DefaultValue="" Name="name" Type="String" />
                                            <asp:Parameter DefaultValue="0" Name="desg" Type="Int32" />
                                            <asp:Parameter DefaultValue="0" Name="branch" Type="Int32" />
                                            <asp:Parameter Name="status" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
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
            $('#empgrid').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>
