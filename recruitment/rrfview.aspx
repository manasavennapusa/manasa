<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rrfview.aspx.cs" Inherits="recruitment_rrfview" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../icomoon/style.css" rel="stylesheet" />

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
                        <h2>Candidate History</h2>
                    </div>
                    
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>CANDIDATE RECRUITMENT HISTORY
                                </div>
                                <span><asp:Button ID="btn_back" runat="server" Text="Back" CssClass="btn btn-info" style="float:right;" OnClick="btn_back_Click" /></span>
                            </div>
                            <div class="widget-body">
                                <div id="wizard">
                                    <ol>
                                        <li>Confirmed Candidates</li>
                                        <li>InProcess Candidates</li>
                                        <li>Rejected Candidates</li>
                                    </ol>

                                    <div>
                                        <p>
                                            <asp:GridView ID="grdConfirmed" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnPreRender="grdConfirmed_PreRender"
                                                EmptyDataText="No data Found." CssClass="table table-condensed table-striped  table-bordered pull-left">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Candidate Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("candidate_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Designation">
                                                       <ItemTemplate>
                                                       <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("designationname") %>'></asp:Label>
                                                      </ItemTemplate>
                                                      </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Mobile No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblmobileno" runat="server" Text='<%# Eval("mobile") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Email Id">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblemailid" runat="server" Text='<%# Eval("emailid") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Qualification">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblqualification" runat="server" Text='<%# Eval("Qualification") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Join Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbljoinstatus" runat="server" Text='<%# Eval("joinstatus") %>'></asp:Label>
                                                            Days
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" RRF Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrrfcode" runat="server" Text='<%# Eval("rrf_code") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Profile">
                                                        <ItemTemplate>
                                                            <%--<a href="javascript:void(window.open('candidatedetails.aspx?id=<%# Eval("Candidate_id") %>&rrf_id=<%# Eval("rrf_id")%>','title','height=550,width=1100,left=100,top=30'));" class="link05">View</a>--%>
                                                            <a href="javascript:void(window.open('candidatedetails.aspx?id=<%# Eval("Candidate_id") %>&rrf_id=<%# Eval("rrf_id")%>','title','height=550,width=1100,left=100,top=30'));" class="link05"><img src="../images/view.png" width="17" height="17" border="0"></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <div class="clearfix"></div>
                                        </p>
                                    </div>

                                    <div>
                                        <p>
                                            <asp:GridView ID="grdprocess" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnPreRender="grdprocess_PreRender1"
                                                EmptyDataText="No data Found." CssClass="table table-condensed table-striped  table-bordered pull-left">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Candidate Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("candidate_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Designation">
                                                      <ItemTemplate>
                                                      <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("designation_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mobile No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblmobileno" runat="server" Text='<%# Eval("mobile") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Email Id">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblemailid" runat="server" Text='<%# Eval("emailid") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Qualification">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblqualification" runat="server" Text='<%# Eval("Qualification") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Join Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbljoinstatus" runat="server" Text='<%# Eval("joinstatus") %>'></asp:Label>
                                                            Days
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" RRF Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrrfcode" runat="server" Text='<%# Eval("rrf_id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Profile">
                                                        <ItemTemplate> 
                                                            <%--<a href="javascript:void(window.open('candidatedetails.aspx?id=<%# Eval("id") %>&rrf_id=<%# Eval("rrf_id")%>','title','height=550,width=1100,left=100,top=30'));" class="link05">View</a>--%>
                                                            <a href="javascript:void(window.open('candidatedetails.aspx?id=<%# Eval("id") %>&rrf_id=<%# Eval("rrf_id")%>','title','height=550,width=1100,left=100,top=30'));" class="link05"><img src="../images/view.png" width="17" height="17" border="0"></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <div class="clearfix"></div>
                                        </p>
                                    </div>

                                    <div>
                                        <p>
                                            <asp:GridView ID="grdRejectedcandidates" runat="server" AutoGenerateColumns="False" CaptionAlign="Left" AllowSorting="True" OnPreRender="grdRejectedcandidates_PreRender"
                                                EmptyDataText="No Data Found." CssClass="table table-condensed table-striped  table-bordered pull-left">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Candidate Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("candidate_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Designation">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("designationname") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mobile No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblmobileno" runat="server" Text='<%# Eval("mobile") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Email Id">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblemailid" runat="server" Text='<%# Eval("emailid") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Qualification">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblqualification" runat="server" Text='<%# Eval("Qualification") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Join Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbljoinstatus" runat="server" Text='<%# Eval("joinstatus") %>'></asp:Label>
                                                            Days
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" RRF Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrrfcode" runat="server" Text='<%# Eval("rrf_code") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Profile">
                                                        <ItemTemplate>
                                                               <%--<a href="javascript:void(window.open('candidatedetails.aspx?id=<%# Eval("Candidate_id") %>&rrf_id=<%# Eval("rrf_id")%>','title','height=550,width=1100,left=100,top=30'));" class="link05">View</a>--%>
                                                            <a href="javascript:void(window.open('candidatedetails.aspx?id=<%# Eval("Candidate_id") %>&rrf_id=<%# Eval("rrf_id")%>','title','height=550,width=1100,left=100,top=30'));" class="link05"><img src="../images/view.png" width="17" height="17" border="0"></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <div class="clearfix"></div>
                                        </p>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="../js/analytics.js"></script>
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

    <script type="text/javascript">
        $("#wizard").bwizard();
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

