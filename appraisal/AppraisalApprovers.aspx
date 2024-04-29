<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppraisalApprovers.aspx.cs" Inherits="appraisal_AppraisalApprovers" %>

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

<!--<html lang="en">
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartDrive Labs</title>
    <meta charset="utf-8" />

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <script lang="JavaScript" type="text/javascript" src="js/popup1.js"></script>
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


</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Appraisal Approvers Master</h2>
                    </div>
                  
                    <div class="clearfix"></div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
                            <ProgressTemplate>
                                <div class="divajax">
                                    <table width="100%">
                                        <tr>
                                            <td align="center" valign="top">
                                                <img src="../images/loading.gif" /></td>
                                        </tr>
                                        <tr>
                                            <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                                        </tr>
                                    </table>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="lblhead" runat="server" Text="Create Appraisal Approvers"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                         <div class="row">
                                                <div class="control-group">
                                                    <label class="control-label">Employee Code</label>
                                                    <div class="controls">
                                                        <asp:TextBox ID="txt_employee" runat="server" CssClass="blue1" Width="210" onkeypress="return false;" onkeydown="return false;" onpaste="return false;">
                                                        </asp:TextBox>
                                                        <a href="JavaScript:newPopup1('pickemployee.aspx');" class="link05">Pick Employee</a>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldor4" ControlToValidate="txt_employee"
                                                            ValidationGroup="v" runat="server" ToolTip="Select Employee" 
                                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                             </div>
                                         <div class="row">
                                                <div class="control-group">
                                                    <label class="control-label">Approver Code</label>
                                                    <div class="controls">
                                                        <asp:TextBox ID="txt_approver" runat="server" CssClass="blue1" Width="210"  onkeypress="return false;" onkeydown="return false;" onpaste="return false;">
                                                        </asp:TextBox>
                                                        <a href="JavaScript:newPopup1('pickapprover.aspx');" class="link05">Pick Employee</a>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_approver"
                                                            ValidationGroup="v" runat="server" ToolTip="Select Approver" 
                                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                             </div>

                                         <div class="row">
                                                <div class="control-group">
                                                    <label class="control-label">Approver Type</label>
                                                    <div class="controls">
                                                        <asp:DropDownList ID="ddl_approvertype" runat="server" CssClass="blue1" Width="210">
                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            <asp:ListItem Value="HR">HR</asp:ListItem>
                                                            <asp:ListItem Value="LM">Line Manager</asp:ListItem>
                                                            <asp:ListItem Value="BH">Business Head</asp:ListItem>
                                                            <asp:ListItem Value="MD">MD</asp:ListItem>
                                                            <asp:ListItem Value="HRD">HRD</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddl_approvertype"
                                                            ValidationGroup="v" runat="server" ToolTip="Select Approver Type" InitialValue="0"
                                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                             </div>

                                        
                                    </div>
                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btn_Save" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btn_Save_Click"
                                            ValidationGroup="v" />&nbsp;
                                            <asp:Button ID="btnreset" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btnreset_Click" CausesValidation="false" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Appraisal Approvers
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                             <asp:GridView ID="gridapprovers" runat="server"  AutoGenerateColumns="False"
                                        DataKeyNames="id"  OnRowEditing="gridapprovers_RowEditing" OnPreRender="gridapprovers_PreRender"
                                        CssClass="table table-condensed table-striped  table-bordered pull-left" OnRowDeleting="gridapprovers_RowDeleting" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="Employee">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Employee")%>
                                                    <asp:Label ID="lblempcode" runat="server" Text='<%# Eval("empcode") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Approver">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblapprovercode" runat="server" Text='<%# Eval("approver_code") %>' Visible="false"></asp:Label>
                                                    <%#DataBinder.Eval(Container.DataItem, "Approver")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Approver Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltype" runat="server" Text='<%# Eval("type") %>' Visible="false"></asp:Label>
                                                    <%#DataBinder.Eval(Container.DataItem, "approver_type")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="20%">
                                                <ItemTemplate>
                                                    <%--<a href="AppraisalApprovers.aspx?sno=<%# Eval("id")%>" class="link05">Edit</a>--%>
                                                    <asp:LinkButton ID="lnk_Edit" CausesValidation="False"  CommandName="Edit"  runat="server"  Text="Edit" ></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnk_DeleteButton" CausesValidation="False"  CommandName="Delete"  runat="server" OnClientClick="return confirm('Are You Sure To Delete?')" Text="Delete" ></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                        </div>
                                        <div class="clearfix"></div>

                                    </div>
                                </div>
                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
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
                $('#gridapprovers').dataTable({
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
