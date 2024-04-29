<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComoffRegistreReport.aspx.cs" Inherits="leave_ComoffRegistreReport" %>


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
            function ValidateData() {
                var frmdate = document.getElementById('<%=txt_sdate.ClientID %>');
                var todate = document.getElementById('<%=txt_edate.ClientID %>');
                if (frmdate.value == "") {
                    alert("Please Enter From Date");
                    return false;
                }
                if (todate.value == "") {
                    alert("Please Enter To Date");
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
                            <h2>CompOff Register</h2>
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
                                        <label class="control-label">From Date</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_sdate" runat="server" CssClass="span3" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                            <cc1:CalendarExtender
                                                ID="CalendarExtender1" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">To Date </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_edate" runat="server" CssClass="span3" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                            <cc1:CalendarExtender
                                                ID="CalendarExtender2" runat="server" PopupButtonID="Image1" TargetControlID="txt_edate">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Compoff Status </label>
                                        <div class="controls">
                                            <asp:DropDownList ID="drp_leavestatus" runat="server" CssClass="span3" Width="">
                                                <asp:ListItem Value="0">Pending</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="1">Approved</asp:ListItem>
                                                <asp:ListItem Value="2">Cancelled</asp:ListItem>
                                                <asp:ListItem Value="3">Rejected</asp:ListItem>
                                                <%--<asp:ListItem Value="6">Approved &amp; Updated</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Employee Name\Code</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_empcode" runat="server" CssClass="span3" Width="" onkeypress="return isAlphaNumeric()"></asp:TextBox>
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
                                            <asp:DropDownList ID="drpdepartment" runat="server" CssClass="blue1" Height=""
                                                OnDataBound="drpdepartment_DataBound">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btn_search" runat="server" CssClass="btn btn-info" OnClick="btn_search_Click" Text="Search" OnClientClick="return ValidateData();" />
                                        <asp:Button ID="btn_export" runat="server" CssClass="btn btn-info" OnClick="btn_export_Click" Text="Export" OnClientClick="return ValidateData();" />
                                        <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info" OnClick="btn_reset_Click" Text="Reset" ValidationGroup="c" />
                                    </div>
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
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Compoff Register
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="empleavegrid" runat="server" EmptyDataText="No records found!!" AutoGenerateColumns="False"
                                            DataKeyNames="empcode" OnPreRender="empleavegrid_PreRender" 
                                            CssClass="table table-condensed table-striped table-hover table-bordered pull-left">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Emp Code" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Emp Name" HeaderStyle-Width="20%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("ename") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="20%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("designation") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Department" HeaderStyle-Width="20%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("department") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="No. of leaves" HeaderStyle-Width="20%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("nod") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               <%-- <asp:TemplateField HeaderStyle-Width="10%" >
                                                    <ItemTemplate>
                                                        <a class="link05" href="javascript:void(window.open('myleavedetails.aspx?sdate=<%=txt_sdate.Text%>&status=<%=drp_leavestatus.SelectedValue%>&edate=<%=txt_edate.Text%>&empcode=<%#DataBinder.Eval(Container.DataItem, "empcode")%>','title','height=300,width=500,left=200,top=20',resizable='no'));">View Detail</a>
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
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#empleavegrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>
