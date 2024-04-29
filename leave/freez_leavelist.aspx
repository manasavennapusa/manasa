<%@ Page Language="C#" AutoEventWireup="true" CodeFile="freez_leavelist.aspx.cs" Inherits="leave_freez_leavelist" %>

<!DOCTYPE html>

<html lang="en">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet">
</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel 
                ID="updatepanel1" 
                runat="server">

                <ContentTemplate>

                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Freeze Leave</h2>
                            </div>
                          
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>

                                            <asp:Label ID="lblhead" runat="server" Text="Freeze Leave"></asp:Label>
                                        </div>
                                    </div>
                                    <div id="tblcountry" runat="server">
                                        <div class="widget-body">
                                            <fieldset>
                                                <div class="control-group">
                                                    <label class="control-label">Period Name</label>
                                                    <div class="controls">
                                                        <asp:DropDownList 
                                                            ID="ddlLeavePeriod" 
                                                            runat="server" 
                                                            CssClass="span4" 
                                                            ViewStateMode="Enabled" OnSelectedIndexChanged="ddlLeavePeriod_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                    </div>
                                                </div>
                                     
                                            </fieldset>
                                        </div>
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
                                           <asp:GridView ID="Grid_Emp"
                                                runat="server" 
                                                DataKeyNames="Month_name" 
                                    
                                                AutoGenerateColumns="False"
                                                CssClass="table table-condensed table-striped table-hover table-bordered pull-left" 
                                                OnPreRender="Grid_Emp_PreRender" >
                                                <PagerSettings PageButtonCount="100"></PagerSettings>
                                            <Columns>
                                                 <asp:BoundField DataField="id" HeaderText="CALENDER ID" SortExpression="id"></asp:BoundField>
                                                    <asp:BoundField DataField="periodname" HeaderText="CALENDER YEAR" SortExpression="YEAR"></asp:BoundField>
                                                                                    <asp:BoundField DataField="Month_name" HeaderText="MONTH" SortExpression="Month_name"></asp:BoundField>
                                                                                 
                                                                                   
                                              <%--   <asp:BoundField DataField="branch_name" HeaderText="Branch" SortExpression="branch_name"></asp:BoundField>--%>
                                                                                   
                                                                                    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="20%">
                                                                                        <ItemTemplate>
                                                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind("status") %>' class="label label-info" Visible='<%#Eval("status").ToString()=="Unfreezed"?true:false%>'></asp:Label>
                                                                                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("status") %>' class="label label-success" Visible='<%#Eval("status").ToString()=="Freezed"?true:false%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="" HeaderStyle-Width="20%">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="LinkButton1" runat="server" EnableTheming="True" OnClick="LinkButton1_Click" ForeColor="#2e86de">Freeze</asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                               </Columns>
                                            </asp:GridView>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.js"></script>
        <script src="../js/moment.js"></script>

        <!-- Data tables JS -->

        <script src="../js/jquery.dataTables.js"></script>

        <!-- Sparkline Chart JS -->
        <script src="../js/sparkline.js"></script>

        <!-- Easy Pie Chart JS -->
        <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

        <!-- Tiny scrollbar js -->
        <script src="../js/tiny-scrollbar.js"></script>

        <!-- Custom Js -->

        <script src="../js/theming.js"></script>
        <script src="../js/custom.js"></script>
         <script type="text/javascript">
             //Data Tables
             $(document).ready(function () {
                 $('#Grid_Emp').dataTable({
                     "sPaginationType": "full_numbers"
                 });
             });
        </script>
    </form>
</body>
</html>

