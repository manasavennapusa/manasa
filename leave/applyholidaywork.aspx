<%@ Page Language="C#" AutoEventWireup="true" CodeFile="applyholidaywork.aspx.cs" Inherits="leave_applyholidaywork" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <link href="js/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="myForm" runat="server">
        <script type="text/javascript">
            function Validate() {
                var sdate = document.getElementById('<%=txt_date.ClientID%>');
                if (sdate.value == "") {
                    alert("Please select from date");
                    return false;
                }
                return true;
            }
        </script>
        <script type="text/javascript">
            function isKey(keyCode) {
                return false;
            }
        </script>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
            runat="server">
            <ProgressTemplate>
                <div class="modal-backdrop fade in">
                    <div class="center">
                        <img src="images/loader.gif" alt="" />
                        Please Wait...
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">

                    <div class="page-header">
                        <div class="pull-left">
                            <h2>Apply Holidaywork</h2>
                        </div>

                        <div class="clearfix"></div>
                    </div>
                    <div class="row-fluid">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Information
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <div class="controls controls-row">
                                            <label class="control-label span3 ">Employee Name</label>
                                            <div class="controls span3">
                                                <asp:Label ID="lbl_emp_name" runat="server"></asp:Label>
                                            </div>
                                            <label class="control-label span3">Gender</label>
                                            <div class="controls span3">
                                                <asp:Label ID="lbl_gender" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls controls-row">
                                            <label class="control-label span3 ">Employee Code</label>
                                            <div class="span3">
                                                <asp:Label ID="lbl_emp_code" runat="server"></asp:Label>
                                            </div>
                                            <label class="control-label span3">Branch</label>
                                            <div class="controls span3">
                                                <asp:Label ID="lbl_branch" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls controls-row">
                                            <label class="control-label span3 ">Department</label>
                                            <div class="span3">
                                                <asp:Label ID="lbl_dept" runat="server"></asp:Label>
                                            </div>
                                            <label class="control-label span3">D.O.J</label>
                                            <div class="span3">
                                                <asp:Label ID="lbl_doj" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls controls-row">
                                            <label class="control-label span3 ">Designation</label>
                                            <div class="span3">
                                                <asp:Label ID="lbl_designation" runat="server"></asp:Label>
                                            </div>
                                            <label class="control-label span3">Status</label>
                                            <div class="span3">
                                                <asp:Label ID="lbl_status" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Holidaywork Application
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label span3">Date</label>
                                                <div class="controls span3">
                                                    <asp:TextBox ID="txt_date" runat="server" CssClass="span3" Width="220px" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                    <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                        <cc1:CalendarExtender
                                                            ID="CalendarExtender1" runat="server" PopupButtonID="img_f" TargetControlID="txt_date">
                                                        </cc1:CalendarExtender>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Extra</label>
                                                <div class="controls span3">
                                                    <asp:DropDownList ID="ddl_extrahour" runat="server" CssClass="span3" Width="220px">
                                                        <asp:ListItem Value="0">4-6 Hours</asp:ListItem>
                                                        <asp:ListItem Value="1">Greater Than 6 Hours</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Add Comment</label>
                                                <div class="controls span3">
                                                    <asp:TextBox ID="txt_comment" runat="server" CssClass="span3" Width="220px" TextMode="MultiLine"
                                                        Height="40px"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btn_sbmit" runat="server" CssClass="btn btn-info pull-right" Style="margin-right: 5px;" Text="Submit" OnClick="btn_sbmit_Click" OnClientClick="return Validate();" />
                                                <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info pull-right" Style="margin-right: 5px;" Text="Reset" OnClick="btn_reset_Click" />
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget no-margin">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Holidaywork History
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="leave_approval_grid" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                            DataSourceID="SqlDataSource2" CellPadding="4" Width="100%" OnPreRender="leave_approval_grid_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Date" HeaderStyle-Width="25%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l5" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Day" HeaderStyle-Width="25%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l6" runat="server" Text='<%# Bind("day") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Posted Date" HeaderStyle-Width="25%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l7" runat="server" Text='<%# Bind("createddate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" HeaderStyle-Width="25%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind("approval_status") %>' class="label label-info" Visible='<%#Eval("approval_status").ToString()=="Pending"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("approval_status") %>' class="label label-success" Visible='<%#Eval("approval_status").ToString()=="Approved"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("approval_status") %>' class="label label-important" Visible='<%#Eval("approval_status").ToString()=="Rejected"?true:false%>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                            ProviderName="System.Data.SqlClient" SelectCommand="sp_leave_fetch_compoff_mark"
                                            SelectCommandType="StoredProcedure">
                                            <SelectParameters>
                                                <asp:SessionParameter DefaultValue="0" Name="empcode" SessionField="empcode" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>
        <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.js"></script>
        <script src="../js/moment.js"></script>
        <!-- Custom Js -->
        <script src="../js/theming.js"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#leave_approval_grid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>


