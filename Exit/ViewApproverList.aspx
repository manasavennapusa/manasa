<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewApproverList.aspx.cs" Inherits="Exit_ViewApproverList" %>

<!DOCTYPE html>
<!--[if lt IE 7]>
    <html class="lt-ie9 lt-ie8 lt-ie7" lang="en">
  <![endif]-->

<!--[if IE 7]>
    <html class="lt-ie9 lt-ie8" lang="en">
  <![endif]-->

<!--[if IE 8]>
    <html class="lt-ie9" lang="en">
  <![endif]-->

<!--[if gt IE 8]>
    <!-->
<html lang="en">
<!--
  <![endif]-->
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <link href="../css/table.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function Validate() {
            var WorkFlowTypeName = document.getElementById('<%=drpWorkFlowType.ClientID%>');

            if (WorkFlowTypeName.value == 0) {
                alert("Please enter the work flow type.");
                WorkFlowTypeName.focus();
                return false;
            }

            return true;
        }
    </script>
</head>
<body>

    <form id="myForm" runat="server" class="form-horizontal no-margin">

        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Approver List</h2>
                    </div>
                    
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    Approver List
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Work Flow Type</label>
                                        <div class="controls">
                                            <asp:HiddenField ID="hdnId" runat="server" />
                                            <asp:DropDownList ID="drpWorkFlowType" runat="server" CssClass="span4" OnSelectedIndexChanged="drpWorkFlowType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="control-group">

                                        <label class="control-label">Employee</label>
                                        <div class="controls">
                                            <table>

                                                <tr>
                                                    <td>
                                                        <asp:ListBox ID="ListBox1" runat="server" Height="200px" Width="300px" SelectionMode="Multiple"></asp:ListBox>

                                                    </td>
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btn1" runat="server" Text=">" Width="45px" OnClick="btn1_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btn2" runat="server" Text=">>" Width="45px" OnClick="btn2_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btn3" runat="server" Text="<" Width="45px" OnClick="btn3_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btn4" runat="server" Text="<<" Width="45px" OnClick="btn4_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <asp:ListBox ID="ListBox2" runat="server" Height="200px" Width="300px" SelectionMode="Multiple"></asp:ListBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lbltxt" runat="server" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="form-actions no-margin" style="text-align: right">
                                        <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Text="Show" OnClick="btnsave_Click" OnClientClick="return Validate()" />
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
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Approver List                
                                           
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="Grid" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                        EmptyDataText="No Data Found" DataKeyNames="Id" OnRowEditing="Grid_RowEditing" OnRowCancelingEdit="Grid_RowCancelingEdit" OnRowUpdating="Grid_RowUpdating" OnRowDeleting="Grid_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Work Flow Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWorkFlowId" runat="server" Text='<%#Eval("WorkFlowId")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                          
                                            <asp:TemplateField HeaderText="Employee">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmployee" runat="server" Text='<%#Eval("UserName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Work Flow Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWorkFlowName" runat="server" Text='<%#Eval("WorkFlowName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Approver Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblApproverCode" runat="server" Text='<%#Eval("ApproverCode")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Approvers">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblApproverName" runat="server" Text='<%#Eval("ApproverName")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="drpEmpCode" runat="server" CssClass="span12"></asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Hr">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHr" runat="server" Text='<%#Eval("Hr")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="Hr" runat="server" Checked='<%#Eval("HrBool")%>' Enabled="false" />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkEdit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="LinkUpdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                                    <asp:LinkButton ID="LinkCancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LinkDelete" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
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
                $('#grdstaytype').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>

        <script>
            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

            ga('create', 'UA-41161221-1', 'srinu.html');
            ga('send', 'pageview');

        </script>
    </form>
</body>
</html>

