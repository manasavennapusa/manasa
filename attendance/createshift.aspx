<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createshift.aspx.cs" Inherits="attendance_createshift" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script src="js/popup.js"></script>
    <script src="js/timepicker.js"></script>
    <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ValidateData() {
            var shiftname = document.getElementById('<%=txtshift.ClientID %>');
            var branch = document.getElementById('<%=ddbranch_id.ClientID %>');
            var fromtime = document.getElementById('<%=txtstime.ClientID %>').value;
            var totime = document.getElementById('<%=txtetime.ClientID %>').value;

            document.getElementById('<%=hide1.ClientID %>').value = fromtime;
            document.getElementById('<%=hide2.ClientID %>').value = totime;
            if (branch.value == 0) {
                alert("Please Select Worklocation");
                return false;
            }

            if (shiftname.value == "") {
                alert("Please Enter Shift Name");
                return false;
            }
            if (fromtime.value == "") {
                alert("Please Enter Shift Start Time");
                return false;
            }
            if (totime.value == "") {
                alert("Please Enter Shift End Time");
                return false;
            }
            return true;
        }
    </script>
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
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                            <div class="page-header">
                                <div class="pull-left">
                                    <h2>Create/View Shift & Shift Mapping</h2>
                                </div>
                              
                                <div class="clearfix"></div>
                            </div>

                            <div class="row-fluid">
                                <div class="widget" style="width:49%; float:left; clear:none">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Create Shift
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                               <div class="control-group">
                                                <label class="control-label">Date Type</label>
                                                <div class="controls">
                                                    <asp:DropDownList 
                                                        ID="ddlDateType" 
                                                        runat="server">
                                                        <asp:ListItem Value="IST">Standard Time (India)</asp:ListItem>
                                                        <asp:ListItem Value="UST">Standard Time (US)</asp:ListItem>
                                                        <asp:ListItem Value="DT">Daylight Time(US)</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Shift Name</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtshift" runat="server" CssClass="blue1" onkeypress="return isalphanumericsplchar()"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Work Location</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddbranch_id" runat="server" CssClass="blue1" DataSourceID="SqlDataSource1"
                                                        DataTextField="branch_name" DataValueField="branch_id" Width="" OnDataBound="ddbranch_DataBound">
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
                                            <div class="control-group">
                                                <label class="control-label">Start Time</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtstime" runat="server" CssClass="blue1" Enabled="False"></asp:TextBox>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                                                    <asp:HiddenField ID="hide1" runat="server" />
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">End Time</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtetime" runat="server" CssClass="blue1" Enabled="False"></asp:TextBox>
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                                                    <asp:HiddenField ID="hide2" runat="server" />
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Shift Description</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtshiftDesc" runat="server" CssClass="blue1" Width="" onkeypress="return isalphanumericsplchar()" TextMode="MultiLine"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="Button3" runat="server" Text="Submit" CssClass="btn btn-info  " OnClick="btnsubmit_Click" OnClientClick="return ValidateData()" ToolTip="Click to submit the created leave" />&nbsp;&nbsp;
                                                <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info  " ValidationGroup="nothing" Text="Reset" OnClick="btn_reset_Click" />
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>

                                <div class="widget"  style="width:49%; float:right; clear:none; height:450px">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                    <asp:Label ID="lblhead" runat="server" Text="Create/Update MachineCode & IP Address"></asp:Label>
                                </div>
                                <a style="float: right;" href="../download/ShiftMapping.xlsx">Download</a>
                            </div>
                            <div class="widget-body">

                                <fieldset>

                                    <div class="control-group" style="margin-top:50px">
                                        <label class="control-label">Branch</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddl_branch" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddl_branch_SelectedIndexChanged" OnDataBound="ddl_branch_DataBound"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Choose File</label>
                                        <div class="controls">
                                            <asp:FileUpload ID="fileUpload" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>

                                    <div class="form-actions" style="margin-top:190px">
                                        <asp:Button ID="btnsbmit" OnClick="btnsbmit_Click" runat="server" CssClass="btn btn-primary pull-right"
                                            Text="Submit"></asp:Button>&nbsp;
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
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Shift
                                </div>
                            </div>
                            <div class="widget-body">

                                <div class="control-group">
                                        <label class="control-label">Select Work Location</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddselbranch" runat="server" CssClass="blue1" DataSourceID="SqlDataSource1"
                                                DataTextField="branch_name" DataValueField="branch_id" OnDataBound="ddselbranch_DataBound"
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
                                    <asp:GridView ID="shiftgrid" runat="server" 
                                        AutoGenerateColumns="False" 
                                        DataKeyNames="shiftid" 
                                        CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                        OnRowEditing="shiftgrid_RowEditing"  
                                        OnRowDeleting="shiftgrid_RowDeleting" 
                                        OnPreRender="shiftgrid_PreRender" EmptyDataText="Sorry No Records Found">
                                        <Columns>
                                           
                                             <asp:TemplateField HeaderText="Work Location " HeaderStyle-Width="20%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Shift Id" HeaderStyle-Width="20%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l0" runat="server" Text='<%# Bind ("shiftid") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Shift Name" HeaderStyle-Width="13%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lsss" runat="server" Text='<%# Bind ("shiftname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Start Time" HeaderStyle-Width="12%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind("starttime")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="End Time" HeaderStyle-Width="12%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l5" runat="server" Text='<%# Bind("endtime")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description" HeaderStyle-Width="20%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind("shift_description")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="15%" HeaderText="Edit">
                                                <ItemTemplate>
                                                    <a class="link05" href="updateshift.aspx?shiftid=<%#DataBinder.Eval(Container.DataItem, "shiftid")%>"
                                                        target="_self"><i class="icon-pencil"></i></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="15%" HeaderText="Delete">
                                                <ItemTemplate>
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

                            <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;">View Employee Shift Mapping</span>

                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example1" class="example_alt_pagination">
                                    <asp:GridView ID="GridView1" runat="server" EmptyDataText="Sorry No Records Found" DataKeyNames="shiftid" 
                                        AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" OnPreRender="GridView1_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Employee Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind("name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Deparment">
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind("department_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Shift Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind("shiftname")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Shift Intime">
                                                <ItemTemplate>
                                                    <asp:Label ID="l5" runat="server" Text='<%# Bind("starttime")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Shift Outtime">
                                                <ItemTemplate>
                                                    <asp:Label ID="l6" runat="server" Text='<%# Bind("endtime")%>'></asp:Label>
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

                        <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#GridView1').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>

         <script type="text/javascript">
             //Data Tables
             $(document).ready(function () {
                 $('#shiftgrid').dataTable({
                     "sPaginationType": "full_numbers"
                 });
             });
        </script>
    </form>
</body>
</html>

