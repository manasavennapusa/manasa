<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewindirectEmployeegoals.aspx.cs" Inherits="appraisal_viewindirectEmployeegoals" %>



<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartDrive Labs</title>
    <meta charset="utf-8" />

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />

    <script src="js/popup1.js"></script>

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
    <style>
        .center {
            position: absolute;
            top: 948px;
            left: 500px;
        }
    </style>
</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
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
                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>View Goals</h2>
                                <%--Initiation--%>
                            </div>

                            <div class="clearfix"></div>
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
                                        <div class="example_alt_pagination">
                                            <asp:GridView ID="gvGoals" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                ShowFooter="false" OnPreRender="gvGoals_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sl.No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex +1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="5%" />
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="Name of the Goal"><%--HeaderText="Role & Responsibilities"--%>
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="lblro" runat="Server" Text='<%# Eval("role") %>'></asp:Label>--%>
                                                            <asp:Label ID="lblro" runat="Server" Text='<%# Eval("role_name_of_the_goal") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <%-- <EditItemTemplate>
                                                                                                        <asp:TextBox ID="text1" CssClass="span11" runat="server" TextMode="MultiLine" Text='<%#Eval("role") %>' MaxLength="2000"></asp:TextBox>
                                                                                                    </EditItemTemplate>--%>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Desired outcome/Impact"><%--HeaderText="KRA"--%>
                                                        <ItemTemplate>
                                                            <%-- <asp:Label ID="Label2" runat="Server" Text='<%# Eval("kca") %>'></asp:Label>--%>
                                                            <asp:Label ID="Label2" runat="Server" Text='<%# Eval("kca_kra_desired_outcome_impact") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <%-- <EditItemTemplate>
                                                                                                        <asp:TextBox ID="text2" CssClass="span11" runat="server" TextMode="MultiLine" Text='<%#Eval("kca") %>' MaxLength="2000"></asp:TextBox>
                                                                                                    </EditItemTemplate>--%>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Milestone to check improvement"><%--HeaderText="KPI"--%>
                                                        <ItemTemplate>
                                                            <%-- <asp:Label ID="Label3" runat="Server" Text='<%# Eval("kpi") %>'></asp:Label>--%>
                                                            <asp:Label ID="Label3" runat="Server" Text='<%# Eval("kpi_milestone_to_check_improvement") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <%--<EditItemTemplate>
                                                                                                        <asp:TextBox ID="text3" runat="server" CssClass="span11" TextMode="MultiLine" Text='<%#Eval("kpi") %>' MaxLength="2000"></asp:TextBox>
                                                                                                    </EditItemTemplate>--%>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Timeline and support required"><%--<asp:TemplateField HeaderText="Weightage(%)">--%>
                                                        <ItemTemplate>
                                                            <%-- <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("weightage") %>'></asp:Label>--%>
                                                            <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("weightage_timeline_and_support_required") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <%--  <EditItemTemplate>
                                                                                                        <asp:TextBox ID="text4" CssClass="span11" runat="server" TextMode="MultiLine" Text='<%#Eval("weightage") %>'></asp:TextBox>
                                                                                                    </EditItemTemplate>--%>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Delete" ItemStyle-Width="26px">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton
                                                                                                            ID="LinkButton1" runat="server" CommandName="Delete" Text="&lt;img src='../images/download_delete.png'/&gt;" OnClientClick="return confirm('Are you sure to delete this Goal?')"></asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>--%>
                                                    <%--  <asp:TemplateField HeaderText="Edit">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton
                                                                                                            ID="LinkButton2" runat="server" CommandName="Edit" Text="&lt;img src='../images/edit.png'/&gt;"></asp:LinkButton>
                                                                                                    </ItemTemplate>

                                                                                                    <EditItemTemplate>
                                                                                                        <asp:LinkButton ID="lnkbtupdate" runat="server" CommandName="Update" class="btn btn-info" Text="Update" />
                                                                                                        <asp:LinkButton ID="lnkbtncancle" runat="server" CommandName="Cancel" class="btn btn-info" Text="Cancel" />
                                                                                                    </EditItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                    <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                                                                                </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>


                                    <div id="Div1" class="form-actions no-margin" runat="server" visible="true" style="text-align: right">
                                        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-info" />
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>

    <!-- Easy Pie Chart JS -->
    <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

    <!-- Tiny scrollbar js -->
    <script src="../js/tiny-scrollbar.js"></script>

    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js"></script>

    <!-- Custom Js -->
    <script src="../js/theming.js"></script>
    <script src="../js/custom.js"></script>

    <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("#wizard").bwizard();
    </script>
    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#gveligible').dataTable({
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
</body>
</html>
