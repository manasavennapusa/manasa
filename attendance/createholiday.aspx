<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createholiday.aspx.cs" Inherits="attendance_createholiday" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        <script type="text/javascript">
            function ValidateData() {

                var year = document.getElementById('<%=ddlyear.ClientID %>');
                var branch = document.getElementById('<%=ddbranch_id.ClientID %>');
                var holidayname = document.getElementById('<%=txtholiday.ClientID %>');
                var date = document.getElementById('<%=txtdate.ClientID %>');

                if (year.value == 0) {
                    alert("Please Select Year");
                    return false;
                }
                if (holidayname.value == "") {
                    alert("Please Enter Holiday Name");
                    return false;
                }
                if (date.value == "") {
                    alert("Please Enter Date");
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
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                            <div class="page-header">
                                <div class="pull-left">
                                    <h2>Holiday</h2>
                                </div>

                                <div class="clearfix"></div>
                            </div>

                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Create Holiday
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">Year</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddlyear" runat="server" Width="" CssClass="span3" ToolTip="Select year">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                           
                                             <div class="control-group">
                                                <label class="control-label">Work Location</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddbranch_id" runat="server" CssClass="blue1" DataSourceID="SqlDataSource1" 
                                                        DataTextField="branch_name" DataValueField="branch_id" Width="" OnDataBound="ddlbranch_DataBound" OnSelectedIndexChanged="ddbranch_id_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        DeleteCommand="DELETE FROM [tbl_intranet_branch_detail] WHERE [branch_id] = @branch_id"
                                                        InsertCommand="INSERT INTO [tbl_intranet_branch_detail] ([branch_id], [branch_name]) VALUES (@branch_id, @branch_name)"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]"
                                                        UpdateCommand="UPDATE [tbl_intranet_branch_detail] SET [branch_name] = @branch_name WHERE [branch_id] = @branch_id">
                                                        <DeleteParameters>
                                                            <asp:Parameter Name="branch_id" Type="Int32" />
                                                        </DeleteParameters>
                                                        <UpdateParameters>
                                                            <asp:Parameter Name="branch_name" Type="String" />
                                                            <asp:Parameter Name="branch_id" Type="Int32" />
                                                        </UpdateParameters>
                                                        <InsertParameters>
                                                            <asp:Parameter Name="branch_id" Type="Int32" />
                                                            <asp:Parameter Name="branch_name" Type="String" />
                                                        </InsertParameters>
                                                    </asp:SqlDataSource>
                                                </div>
                                            </div>

                                          <%--  <div class="control-group">
                                                <label class="control-label">Work Location</label>
                                                <div class="controls">
                                                    <asp:DropDownList runat="server" ID="ddbranch_id" DataSourceID="SqlDataSource2" DataTextField="branch_name" DataValueField="branch_id" OnDataBound="ddlbranch_DataBound">
                                                    </asp:DropDownList>
                                                   <%-- <asp:ListBox runat="server" ID="ddbranch_id"  DataSourceID="SqlDataSource2" SelectionMode="Multiple"
                                                        DataTextField="branch_name" DataValueField="branch_id" OnDataBound="ddlbranch_DataBound">
                                                       
                                                    </asp:ListBox>--
                                                  
                                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        DeleteCommand="DELETE FROM [tbl_intranet_branch_detail] WHERE [branch_id] = @branch_id"
                                                        InsertCommand="INSERT INTO [tbl_intranet_branch_detail] ([branch_id], [branch_name]) VALUES (@branch_id, @branch_name)"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]"
                                                        UpdateCommand="UPDATE [tbl_intranet_branch_detail] SET [branch_name] = @branch_name WHERE [branch_id] = @branch_id">
                                                        <DeleteParameters>
                                                            <asp:Parameter Name="branch_id" Type="Int32" />
                                                        </DeleteParameters>
                                                        <UpdateParameters>
                                                            <asp:Parameter Name="branch_name" Type="String" />
                                                            <asp:Parameter Name="branch_id" Type="Int32" />
                                                        </UpdateParameters>
                                                        <InsertParameters>
                                                            <asp:Parameter Name="branch_id" Type="Int32" />
                                                            <asp:Parameter Name="branch_name" Type="String" />
                                                        </InsertParameters>
                                                    </asp:SqlDataSource>
                                                </div>
                                            </div>--%>

                                            <div class="control-group">
                                                <label class="control-label">Shift</label>
                                                <div class="controls">
                                                   <asp:DropDownList ID="ddl_shift" runat="server" CssClass="blue1" OnDataBound="ddl_shift_DataBound">

                                                   </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Name</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtholiday" runat="server" Width="" CssClass="span3" ToolTip="Add Holiday Name" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Detail</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtdetail" runat="server" Width="" CssClass="span3" TextMode="MultiLine" ToolTip="Add detail of the holiday" MaxLength="200" onkeypress="return isalphanumericsplchar()"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Date</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtdate" runat="server" CssClass="span3 datepicker" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                    <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                            <cc1:CalendarExtender
                                                                ID="CalendarExtender1" runat="server" PopupButtonID="img_f" TargetControlID="txtdate">
                                                            </cc1:CalendarExtender>
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="btn btn-info " OnClick="btnsbmit_Click" OnClientClick="return ValidateData();" ToolTip="Click here to submit the new holiday" />&nbsp;&nbsp;
                                                <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info " Text="Reset" OnClick="btn_reset_Click" />
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>

                            <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Holiday List
                                </div>
                            </div>
                            <div class="widget-body">

                                <div class="control-group">
                                        <label class="control-label">Select WorkLocation</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddselbranch" runat="server" CssClass="blue1" DataSourceID="SqlDataSource1"
                                                DataTextField="branch_name" DataValueField="branch_id" OnDataBound="ddlbranch_DataBound1"
                                                OnSelectedIndexChanged="ddselbranch_SelectedIndexChanged" Width="" AutoPostBack="True">
                                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                DeleteCommand="DELETE FROM [tbl_intranet_branch_detail] WHERE [branch_id] = @branch_id"
                                                InsertCommand="INSERT INTO [tbl_intranet_branch_detail] ([branch_id], [branch_name]) VALUES (@branch_id, @branch_name)"
                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]"
                                                UpdateCommand="UPDATE [tbl_intranet_branch_detail] SET [branch_name] = @branch_name WHERE [branch_id] = @branch_id">
                                                <DeleteParameters>
                                                    <asp:Parameter Name="branch_id" Type="Int32" />
                                                </DeleteParameters>
                                                <UpdateParameters>
                                                    <asp:Parameter Name="branch_name" Type="String" />
                                                    <asp:Parameter Name="branch_id" Type="Int32" />
                                                </UpdateParameters>
                                                <InsertParameters>
                                                    <asp:Parameter Name="branch_id" Type="Int32" />
                                                    <asp:Parameter Name="branch_name" Type="String" />
                                                </InsertParameters>
                                            </asp:SqlDataSource>
                                        </div>
                                    </div>

                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="holidaygrid" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="holidayid"
                                        CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" OnPageIndexChanging="holidaygrid_PageIndexChanging"
                                        OnRowDeleting="holidaygrid_RowDeleting" OnRowEditing="holidaygrid_RowEditing" OnPreRender="holidaygrid_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Work Location" HeaderStyle-Width="16%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind("branch_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name" HeaderStyle-Width="26%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind("name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Shift Name" HeaderStyle-Width="11%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_shift" runat="server" Text='<%# Bind("shiftname")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date" HeaderStyle-Width="16%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l411" runat="server" Text='<%# Bind("date")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Day of Week" HeaderStyle-Width="16%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l41" runat="server" Text='<%# Bind("dayofweek")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="15%">
                                                <ItemTemplate>
                                                    <a class="link05" href="updateholiday.aspx?holidayid=<%#DataBinder.Eval(Container.DataItem, "holidayid")%>"
                                                        target="_self"><i class="icon-pencil"></i></a>|
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" CssClass="link05"
                                                        OnClientClick="return confirm(' Do you want to Delete this record?');"><i class="icon-remove"></i></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle Height="5px" />
                                    </asp:GridView>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                    <div>
                        <br />
                    </div>
                       <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>

        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#holidaygrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>


