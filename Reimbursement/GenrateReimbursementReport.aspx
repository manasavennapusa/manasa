<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenrateReimbursementReport.aspx.cs" Inherits="Reimbursement_GenrateReimbursementReport"
 Title="SmartDrive Labs Technologies India Pvt. Ltd. : Employee Master View" %>
<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartHR</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
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
                        <h2> Reimbursement Details</h2>
                    </div>
                  
                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Search 
                                </div>
                                
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <div class="controls-row">
                                            <label class="control-label span2">Work Location</label>
                                            <div class="span2">
                                                <asp:DropDownList ID="drpbranch" runat="server" CssClass="span2" Height="" Width="200px"
                                                    DataSourceID="sql_data_branch" DataTextField="branch_name" DataValueField="Branch_Id"
                                                    OnDataBound="drpbranch_DataBound" AutoPostBack="True" OnSelectedIndexChanged="drpbranch_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:SqlDataSource
                                                    ID="sql_data_branch" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail] order by branch_name"></asp:SqlDataSource>
                                            </div>
                                            <label class="control-label span2">Department</label>
                                            <div class=" span2">
                                                <asp:DropDownList ID="drpdepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpdepartment_SelectedIndexChanged" CssClass="span2" Height=""
                                                    Width="200px" OnDataBound="drpdepartment_DataBound">
                                                </asp:DropDownList>
                                            </div>
                                            <label class="control-label span2 ">Designation</label>
                                            <div class=" span2">
                                                <asp:DropDownList ID="drpdegination" runat="server" CssClass="span2" Width="200px"
                                                    OnDataBound="dd_designation_DataBound">
                                                </asp:DropDownList>
                                                <asp:SqlDataSource
                                                    ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail]"></asp:SqlDataSource>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls-row">
                                            <label class="control-label span2">From Date</label>
                                            <div class=" span2">
                                              <asp:TextBox ID="txtfromdate" runat="server" CssClass="span3" Width="200px"></asp:TextBox>
                                                <%-- <asp:Image ID="Image1" runat="server" ImageUrl="~/img/clndr.gif" />--%>
                                                    <cc1:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txtfromdate" Enabled="True"></cc1:CalendarExtender>
                                            </div>
                                            <label class="control-label span2 ">To Date</label>
                                            <div class="span3">
                                                <asp:TextBox ID="txttodate" runat="server" CssClass="span3" Width="200px"></asp:TextBox>
                                                 <%-- <asp:Image ID="Image2" runat="server" ImageUrl="~/img/clndr.gif" />--%>
                                                    <cc1:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender2" runat="server" PopupButtonID="Image1" TargetControlID="txttodate" Enabled="True"></cc1:CalendarExtender>
                                            </div>
                                            <div class="span3">
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
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View 
                                </div>
                                <div class="span3" style="float:right">
                                 <asp:Button ID="btn_export" runat="server" CssClass="btn btn-primary pull-right" Text="Export" OnClick="btn_export_Click"  />
                                 
                                 </div>                                
                            </div>
                         
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="Reimgrid" runat="server" DataKeyNames="empcode" AutoGenerateColumns="False"
                                        EmptyDataText="No Such Reimbursment Record !" class="table table-condensed table-striped table-hover table-bordered pull-left">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Employee Code">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l0" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Employee Name">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="26%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Department">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="16%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Designation">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                            <asp:TemplateField HeaderText="Grade">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="5%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind ("grade") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="RID">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="5%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l5" runat="server" Text='<%# Bind ("RID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Submitted Date">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l6" runat="server" Text='<%# Bind ("SubmitDate") %>'></asp:Label>
                                                      <%--<%# Convert.ToDateTime(Eval("SubmitDate")).ToShortDateString() %>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Requested Amount">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l7" runat="server" Text='<%# Bind ("Ammount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Sanction Amount">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l8" runat="server" Text='<%# Bind ("FinalAmmount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Date Of Payment">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l9" runat="server"  Text='<%# Bind("UpdatedDate") %>'></asp:Label>
                                                    <%-- <%# Convert.ToDateTime(Eval("UpdatedDate")).ToShortDateString() %>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField>
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <%#linkreset(Convert.ToString(DataBinder.Eval(Container.DataItem, "empcode")))   %>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                        <HeaderStyle CssClass="" />
                                        <FooterStyle CssClass="" />
                                        <RowStyle Height="5px" />
                                        <PagerStyle CssClass=""></PagerStyle>
                                    </asp:GridView>

                                    <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:intranetConnectionString  %>"
                                        runat="server" SelectCommand="sp_leave_fetch_emp_detail" SelectCommandType="StoredProcedure">
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

