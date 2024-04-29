<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VIEWREAING.aspx.cs" Inherits="appraisal_VIEWREAING" %>




<!DOCTYPE html>

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
                        <h2>My Evaluation Status</h2>
                    </div>
                    
                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
               

                    <div class="row-fluid" id="emplist" runat="server">
                        <div class="span12">
                            <div class="widget no-margin">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                 
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="gveligible" runat="server" AutoGenerateColumns="false" CellSpacing="0" OnPreRender="gveligible_PreRender" DataKeyNames="empcode"
                                            CssClass="table table-condensed table-striped  table-bordered pull-left" OnRowDeleting="gveligible_RowDeleting">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl.NO">

                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempcode" runat="server" Text='<%# Eval ("empcode") %>'></asp:Label></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempname" runat="server" Text='<%# Eval ("name") %>'></asp:Label></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Goal Status" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("GoalStatus") %>' class="label label-info" Visible='<%#Eval("GoalStatus").ToString()=="Initiated"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("GoalStatus") %>' class="label label-info" Visible='<%#Eval("GoalStatus").ToString()=="Goal Cycle 1 At Emp"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("GoalStatus") %>' class="label label-info" Visible='<%#Eval("GoalStatus").ToString()=="Goal Cycle 1 At LM"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("GoalStatus") %>' class="label label-info" Visible='<%#Eval("GoalStatus").ToString()=="Goal Cycle 1 At BUH"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("GoalStatus") %>' class="label label-info" Visible='<%#Eval("GoalStatus").ToString()=="Goal Cycle 2 At Emp"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("GoalStatus") %>' class="label label-info" Visible='<%#Eval("GoalStatus").ToString()=="Goal Cycle 2 At LM"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("GoalStatus") %>' class="label label-info" Visible='<%#Eval("GoalStatus").ToString()=="Goal Cycle 2 At BUH"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("GoalStatus") %>' class="label label-info" Visible='<%#Eval("GoalStatus").ToString()=="Cycle 2 Initiated"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("GoalStatus") %>' class="label label-important" Visible='<%#Eval("GoalStatus").ToString()=="Not Inititated"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("GoalStatus") %>' class="label label-success" Visible='<%#Eval("GoalStatus").ToString()=="Goal Cycle 1 Completed"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("GoalStatus") %>' class="label label-success" Visible='<%#Eval("GoalStatus").ToString()=="Goal Cycle 2 Completed"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("GoalStatus") %>' class="label label-success" Visible='<%#Eval("GoalStatus").ToString()=="Freezed"?true:false%>'></asp:Label>

                                                        <%-- <asp:Label ID="lblgoalstatus" runat="server" Text='<%# Eval ("GoalStatus") %>'></asp:Label></a>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="My Rating">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label111555" runat="server" Text='<%# Bind("RatingStatus") %>' class="label label-important" Visible='<%#Eval("RatingStatus").ToString()=="Pending"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label666" runat="server" Text='<%# Bind("RatingStatus") %>' class="label label-info" Visible='<%#Eval("RatingStatus").ToString()=="Pending At md"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label13ee" runat="server" Text='<%# Bind("RatingStatus") %>' class="label label-info" Visible='<%#Eval("RatingStatus").ToString()=="Pending at LM"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label145555" runat="server" Text='<%# Bind("RatingStatus") %>' class="label label-info" Visible='<%#Eval("RatingStatus").ToString()=="Pending at BH"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label333" runat="server" Text='<%# Bind("RatingStatus") %>' class="label label-success" Visible='<%#Eval("RatingStatus").ToString()=="Rating Completed"?true:false%>'></asp:Label>
                                                        <%--  <asp:Label ID="lblratingstatus" runat="server" Text='<%# Eval ("RatingStatus")%>'></asp:Label></a>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Increment Status" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1fdsfdsf1" runat="server" Text='<%# Bind("IncreamentStatus") %>' class="label label-important" Visible='<%#Eval("IncreamentStatus").ToString()=="Not Inititated"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label1fsfd6" runat="server" Text='<%# Bind("IncreamentStatus") %>' class="label label-info" Visible='<%#Eval("IncreamentStatus").ToString()=="Inititated"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label1fdfs3" runat="server" Text='<%# Bind("IncreamentStatus") %>' class="label label-success" Visible='<%#Eval("IncreamentStatus").ToString()=="Approved with HRD"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Label1fsf7" runat="server" Text='<%# Bind("IncreamentStatus") %>' class="label label-important" Visible='<%#Eval("IncreamentStatus").ToString()=="Rejected"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Labelfsdf18" runat="server" Text='<%# Bind("IncreamentStatus") %>' class="label label-success" Visible='<%#Eval("IncreamentStatus").ToString()=="Approved"?true:false%>'></asp:Label>
                                                        <asp:Label ID="Labelfdf19" runat="server" Text='<%# Bind("IncreamentStatus") %>' class="label label-success" Visible='<%#Eval("IncreamentStatus").ToString()=="Approved with MD"?true:false%>'></asp:Label>

                                                        <%--  <asp:Label ID="lblratingstatus" runat="server" Text='<%# Eval ("RatingStatus")%>'></asp:Label></a>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:HyperLinkField HeaderText="View" DataNavigateUrlFields="empcode" DataNavigateUrlFormatString="~/appraisal/ViewratingEMP.aspx?empcode={0}"
                                                    Text="&lt;img src='../images/view.png' /&gt;">
                                                    
                                                </asp:HyperLinkField>
                                                <asp:HyperLinkField HeaderText="Increment View" DataNavigateUrlFields="empcode" DataNavigateUrlFormatString="~/appraisal/HRIncrementreport.aspx?empcode={0}"
                                                    Text="View" Visible="false">
                                                    <ControlStyle CssClass="link05" Width="6%" />
                                                </asp:HyperLinkField>
                                                <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="10%" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkdelete" runat="server" OnClientClick="return confirm('Are you sure to delete this entry?')" CommandName="Delete" CssClass="link05" Text="Delete" ToolTip="Delete" />&nbsp;
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
    </form>
</body>
</html>

